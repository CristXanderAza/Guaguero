

using Guaguero.Domain.Base;

namespace Guaguero.Domain.Interfaces.PersistenceInterfaces
{
    public interface IRepositoryBase<T, I> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(I id);
        Task<Result<T>> Save(T entity);
        Task<Result<T>> Update(T entity);
        Task<Result<T>> Delete(I id);
        Task<IEnumerable<T>> Where(Func<T,bool> predicate);
        Task<T> FirstOrDefault(Func<T, bool> predicate);

    }
}
