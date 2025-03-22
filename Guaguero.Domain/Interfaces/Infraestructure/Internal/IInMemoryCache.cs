

namespace Guaguero.Domain.Interfaces.Infraestructure.Internal
{
    public interface IInMemoryCache<T, I> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(I id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(I id);
    }
}
