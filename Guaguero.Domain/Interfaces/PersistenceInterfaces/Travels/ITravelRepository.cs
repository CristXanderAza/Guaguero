using Guaguero.Domain.Entities.Logistic.Routes;
using Guaguero.Domain.Entities.Travels;

namespace Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels
{
    public interface ITravelRepository : IRepositoryBase<Travel, Guid>
    {
        Task<IEnumerable<Travel>> GetTravelsInRoute(int  routeId, int stepIndex);
        Task<IEnumerable<Travel>> GetTravelsInRouteAndWaypoint(int routeId, int sindicateID, int stepIndex);
        Task<IEnumerable<WayPoint>> GetWayPointsOfTravel(Guid travelID);
        Task<WayPoint> GetNearestWayPoint(Guid travelID, Coordinate coordinate);
        Task<WayPoint> GetWaypointByStep(int routeID, int stepIndex);
        Task<Travel> GetTravelByEmpleoyeeID(Guid empleoyeeID);

        Task<int> GetBusCapacity(int busID);
    }
}
