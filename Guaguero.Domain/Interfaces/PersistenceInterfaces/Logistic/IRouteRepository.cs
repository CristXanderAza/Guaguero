using Guaguero.Domain.Entities.Logistic.Routes;

namespace Guaguero.Domain.Interfaces.PersistenceInterfaces.Logistic
{
    public interface IRouteRepository : IRepositoryBase<Route, int>
    {
        Task<IEnumerable<Route>> GetRoutesContaining(string routeName);
        Task<WayPoint> GetNearestWayPoint(int routeID, Coordinate coordinate);
        Task<IEnumerable<WayPoint>> GetWayPoints(int routeID);
    }
}
