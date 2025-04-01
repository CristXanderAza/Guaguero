using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Interfaces.Infraestructure.Internal;
using Microsoft.Extensions.Caching.Memory;

namespace Guaguero.Infraestructure.Internal.TravelCache
{
    public class TravelCache : IInMemoryCache<Travel, Guid>
    {
        private IMemoryCache _memoryCache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromHours(2);


        public TravelCache(IMemoryCache cache)
        {
            _memoryCache = cache;
        
        }

        public async Task<Travel> Add(Travel entity)
        {
            _memoryCache.Set(entity.TravelID,entity, _cacheDuration);
            return entity;
        }

        public async Task<Travel> Delete(Guid id)
        {
            if (_memoryCache.TryGetValue(id, out Travel obj))
            { // Modificar el objeto
                _memoryCache.Remove(id);
                return obj;
            }
            return null;
        }

        public async Task<Travel> FindById(Guid id)
        {
            _memoryCache.TryGetValue(id, out Travel entity);
            if(entity != null)
            {
                return entity;
            }
            return null;
        }

        public Task<IEnumerable<Travel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Travel> Update(Travel entity)
        {
            if (_memoryCache.TryGetValue(entity.TravelID, out Travel obj))
            { // Modificar el objeto
                _memoryCache.Set(obj.TravelID, entity, _cacheDuration);
                return entity;
            }
            return null;

        }
    }
}
