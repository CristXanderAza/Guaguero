using Guaguero.Domain.Entities.Sindicatos;


namespace Guaguero.Domain.Interfaces.PersistenceInterfaces.Sindicatos
{
    public interface ISindicatoRepository : IRepositoryBase<Sindicato, int>
    {
        Task<IEnumerable<Sindicato>> GetSindicatoContaining(string nae);
    }
}
