using Guaguero.Application.Events.Travels;
using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Logistic.Routes;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Interfaces.Infraestructure.Internal;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels;
using Guaguero.Domain.Utils;
using MediatR;

namespace Guaguero.Application.Commands.Travels
{
    public class UpdateTravelPositionCommand : IRequest<Result<Unit>>
    {
        public Guid EmpleoyeeID { get; set; }
        public Guid TravelID { get; set; }
        public double TravelSpeed { get; set; }
        public Coordinate Coordinate { get; set; }
        public string ConnectionID { get; set; }
    }

    public class UpdateTravelPositionCommandHandler : IRequestHandler<UpdateTravelPositionCommand, Result<Unit>>
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IInMemoryCache<Travel, Guid> _travelCache;

        private readonly IMediator _mediator;
        private readonly IQuotaRepository _quotaRepository;

        public UpdateTravelPositionCommandHandler(ITravelRepository travelRepository, IInMemoryCache<Travel, Guid> travelCache,
            IMediator mediator, IQuotaRepository quotaRepository)
        {
            _travelRepository = travelRepository;
            _travelCache = travelCache;
            _mediator = mediator;
            _quotaRepository = quotaRepository;
        }


        public async Task<Result<Unit>> Handle(UpdateTravelPositionCommand request, CancellationToken cancellationToken)
        {
            Travel travel = await _getTravel(request.TravelID);
            if (travel == null)
                return Result<Unit>.Fail("El viaje seleccionado no existe");
            travel.ActualLocation = request.Coordinate;
            if (travel.NearestWayPoint == null)
                travel.NearestWayPoint = await _travelRepository.GetWaypointByStep(travel.TravelID, travel.ActualStep);
            double distance = GeoUtils.Haversine(travel.ActualLocation, travel.NearestWayPoint.Coordinate);

            if (travel.StepState == StepState.Green && distance <= 1.5)
            {
                 travel.StepState = StepState.Yellow;
            }
            else if(travel.StepState == StepState.Yellow && distance <= 0.5)
            {
                travel.StepState = StepState.Red;
                await NotifyArrivals(travel.TravelID, travel.ActualStep, request.ConnectionID);
            }
            else if (travel.StepState == StepState.Red && distance >= 0.8)
            {
                if (travel.ActualStep < travel.TotalSteps)
                {
                    travel.StepState = StepState.Green;
                    travel.ActualStep++;
                    travel.NearestWayPoint = await _travelRepository.GetWaypointByStep(travel.TravelID, travel.ActualStep);
                }
                else 
                {
                    travel.Status = TravelState.Finished;
                }

            }
            await NotifyChange(travel);
            await _travelRepository.Update(travel);
            await _travelCache.Update(travel);
            return Result<Unit>.Success(Unit.Value);
        }

        private async Task<Travel> _getTravel(Guid travelID)
        {

            Travel travel = await _travelCache.FindById(travelID);
            if (travel == null)
                travel = await _travelRepository.FindById(travelID);
            return travel;
        }

        private async Task NotifyChange(Travel travel)
        {
            var notif = new TravelLocationChangeNotification()
            {
                TravelID = travel.TravelID,
                ActualLocation = travel.ActualLocation,
                NextStep = travel.ActualStep,
                StepState = travel.StepState.ToString(),
                WaypointLocation = travel.NearestWayPoint.Coordinate
            };
            await _mediator.Publish(notif);
            //await _mediator.Publish(new TravelPositionChangedNotification(travel.TravelID, travel.ActualLocation));
        }

        private async Task NotifyArrivals(Guid travelID, int stepIndex, string connectionId)
        {
            IEnumerable<Quota> quotas = await _quotaRepository.GetQuotaOfTravelInStep(travelID, stepIndex);
            var qFilteredList = quotas.Where(q => q.Status == QuotaState.Confirmed);
            TravelArrivalEvent arrivalEvent = new TravelArrivalEvent()
            {
                Quotas = qFilteredList,
                ConnectionID  = connectionId,
                TravelID = travelID
            };
            await _mediator.Publish(arrivalEvent);
        }
    }
}
