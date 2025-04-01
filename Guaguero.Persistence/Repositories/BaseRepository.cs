using Guaguero.Domain.Base;
using Guaguero.Domain.Interfaces.PersistenceInterfaces;
using Guaguero.Persistence.Base;
using Microsoft.EntityFrameworkCore;

namespace Guaguero.Persistence.Repositories
{
    public class BaseRepository<TEntity, Id> : IRepositoryBase<TEntity, Id> where TEntity : class
    {

        protected readonly GuagueroContext _context;
        private DbSet<TEntity> Entity { get; set; }

        protected BaseRepository(GuagueroContext context)
        {
            _context = context;
            Entity = _context.Set<TEntity>();
        }


        public virtual async Task<Result<TEntity>> Delete(Id id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> FindById(Id id)
        {
            return await Entity.FindAsync(id);
        }

        public virtual async Task<TEntity> FirstOrDefault(Func<TEntity, bool> predicate)
        {
            return Entity.Where(predicate).FirstOrDefault();
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            return await Entity.ToListAsync();
        }

        public virtual async Task<Result<TEntity>> Save(TEntity entity)
        {
           
            try
            {
                Entity.Add(entity);
                await _context.SaveChangesAsync();
                return Result<TEntity>.Success(entity);
            }
            catch (Exception ex)
            {
                return Result<TEntity>.Fail(ex.Message);
            }
        }

        public virtual async Task<Result<TEntity>> Update(TEntity entity)
        {
            try
            {
                Entity.Update(entity);
                await _context.SaveChangesAsync();
                return Result<TEntity>.Success(entity);
            }
            catch (Exception ex)
            {
               return  Result<TEntity>.Fail(ex.Message);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> Where(Func<TEntity, bool> predicate)
            => Entity.Where(predicate).ToList();
    }
}
