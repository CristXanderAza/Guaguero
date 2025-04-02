using Guaguero.Application.DTOs.Travel;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Interfaces.Infraestructure.Internal;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Application.Queries.Travels
{
    public class GetTravelInRouteBeforeWaypointQuery : IRequest<IEnumerable<TravelResumeDTO>>
    {
        public int RouteId { get; set; }
        public int Step { get; set; }
        public int SindicatoID { get; set; }
    }

    public class GetTravelInRouteBeforeWaypointQueryHandler : IRequestHandler<GetTravelInRouteBeforeWaypointQuery, IEnumerable<TravelResumeDTO>>
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IInMemoryCache<Travel, Guid> _travelCache;

        public GetTravelInRouteBeforeWaypointQueryHandler(ITravelRepository travelRepository, IInMemoryCache<Travel, Guid> travelCache)
        {
            _travelRepository = travelRepository;
            _travelCache = travelCache;
        }

        public async Task<IEnumerable<TravelResumeDTO>> Handle(GetTravelInRouteBeforeWaypointQuery request, CancellationToken cancellationToken)
        {
            var tr = await _travelRepository.GetTravelsInRouteAndWaypoint(request.RouteId, request.SindicatoID, request.Step);
            return tr.Select(t => new TravelResumeDTO
            {
                TravelID = t.TravelID,
                ArrivalTime = t.Arrival,
                Step = t.ActualStep,
                StepState = t.StepState.ToString(),
                DisponiblesSteats = t.SeetsDisponibles
            });
        }
    }
}
