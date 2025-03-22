using Guaguero.Domain.Entities.Travels;


namespace Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels
{
    public interface ITravelRepository : IRepositoryBase<Travel, Guid>
    {
        Task<IEnumerable<Travel>> GetTravelsInRoute(int  routeId, int stepIndex);
        Task<IEnumerable<Travel>> GetTravelsInRouteAndWaypoint(int routeId, int sindicateID, int stepIndex);

    }
}
