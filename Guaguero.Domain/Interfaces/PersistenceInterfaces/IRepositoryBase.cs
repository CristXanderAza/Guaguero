

namespace Guaguero.Domain.Interfaces.PersistenceInterfaces
{
    public interface IRepositoryBase<T, I> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(I id);
        Task<T> Save(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(I id);
        Task<IEnumerable<T>> Where(Func<T,bool> predicate);
        Task<T> FirstOrDefault(Func<T, bool> predicate);

    }
}
