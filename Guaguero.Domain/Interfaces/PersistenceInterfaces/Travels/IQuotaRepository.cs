using Guaguero.Domain.Entities.Travels;


namespace Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels
{
    public interface IQuotaRepository : IRepositoryBase<Quota, Guid>
    {
        Task<IEnumerable<Quota>> GetQuotaOfTravelInStep(Guid Travel, int step);
    }
}
