﻿using Guaguero.Domain.Entities.Logistic.Routes;
using Guaguero.Domain.Entities.Sindicatos;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels;
using Guaguero.Persistence.Base;
using Microsoft.EntityFrameworkCore;


namespace Guaguero.Persistence.Repositories.Travels
{
    public class TravelRepository : BaseRepository<Travel, Guid>, ITravelRepository
    {
        public TravelRepository(GuagueroContext context) : base(context)
        {
        }

        public async Task<int> GetBusCapacity(int busID)
            => (await _context.Buses.FindAsync(busID)).Capacidad;      




        public Task<WayPoint> GetNearestWayPoint(Guid travelID, Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        public async Task<Travel> GetTravelByEmpleoyeeID(Guid empleoyeeID)
        {
            return _context.Travels.FirstOrDefault(x => x.EmpleoyeeID == empleoyeeID);
        }

        public async Task<IEnumerable<Travel>> GetTravelsInRoute(int routeId, int stepIndex)
            => await _context.Travels.Where(x => x.RouteID == routeId && x.ActualStep <= stepIndex)
                .ToListAsync();

        public async Task<IEnumerable<Travel>> GetTravelsInRouteAndWaypoint(int routeId, int sindicateID, int stepIndex)
            => await _context.Travels.Where(x => x.RouteID == routeId && x.SindicatoID == sindicateID && x.ActualStep <= stepIndex)
                .ToListAsync();

        public async Task<WayPoint> GetWaypointByStep(int routeID, int stepIndex)
            => await _context.WayPoints.Where(wp => wp.RouteID == routeID && wp.StepIndex == stepIndex).FirstOrDefaultAsync();

        public async Task<IEnumerable<WayPoint>> GetWayPointsOfTravel(Guid travelID)
            => await (from wp in _context.WayPoints
               join t in _context.Travels on wp.RouteID equals t.RouteID
               where t.TravelID == travelID
               select wp).ToListAsync();
    }
}
