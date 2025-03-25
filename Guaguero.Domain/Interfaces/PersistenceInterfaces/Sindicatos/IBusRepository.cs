using Guaguero.Domain.Entities.Sindicatos;

namespace Guaguero.Domain.Interfaces.PersistenceInterfaces.Sindicatos
{
    public interface IBusRepository : IRepositoryBase<Bus, int>
    {
        Task<IEnumerable<Bus>> GetBusOfSindicato(int id);
    }
}
