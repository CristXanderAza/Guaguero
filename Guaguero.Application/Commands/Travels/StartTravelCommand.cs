using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Logistic.Routes;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Interfaces.Infraestructure.Internal;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels;
using MediatR;

namespace Guaguero.Application.Commands.Travels
{
    public class StartTravelCommand : IRequest<Result<Unit>>
    {
        public Guid TravelId { get; set; }
        public Guid EmpleoyeeID { get; set; }
        public int InformalArrivals { get; set; }   
        public Coordinate StartLocation { get; set; }



    }

    public class StartTravelCommandHandler : IRequestHandler<StartTravelCommand, Result<Unit>>
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IInMemoryCache<Travel, Guid> _travelCache;

        public StartTravelCommandHandler(ITravelRepository travelRepository, IInMemoryCache<Travel, Guid> travelCache)
        {
            _travelRepository = travelRepository;
            _travelCache = travelCache;
        }

        public async Task<Result<Unit>> Handle(StartTravelCommand request, CancellationToken cancellationToken)
        {
            var tr = await _travelRepository.FindById(request.TravelId);
            int busCapacidad = await _travelRepository.GetBusCapacity(tr.BusID);
            if (tr == null)
                return Result<Unit>.Fail("El viaje no existe");
            if(tr.Status != TravelState.Pending)
                return Result<Unit>.Fail("El viaje ya ha inciado");
            if(tr.EmpleoyeeID != request.EmpleoyeeID)
                return Result<Unit>.Fail("No esta autorizado a iniciar este viaje");
            if(tr.SeetsDisponibles < request.InformalArrivals)
                return Result<Unit>.Fail("Los asientos reservados son mayores a la capacidad");
            
            
            if(request.InformalArrivals == tr.Bus.Capacidad)
            {
                tr.Status = TravelState.Finished;
            }
            else
            {
                tr.Status = TravelState.InProgress;
                tr.ActualLocation = request.StartLocation;
                tr.BusCapacity = busCapacidad;
            }
            tr.InformalQuotas = request.InformalArrivals;
            await _travelRepository.Update(tr);
            await _travelCache.Add(tr);
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
