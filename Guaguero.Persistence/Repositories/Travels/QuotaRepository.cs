using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels;
using Guaguero.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Repositories.Travels
{
    public class QuotaRepository : BaseRepository<Quota, Guid>, IQuotaRepository
    {
        protected QuotaRepository(GuagueroContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Quota>> GetQuotaOfTravelInStep(Guid Travel, int step)
        {
            return await _context.Quotas.Where(q => q.TravelID == Travel && q.EntryStep == step)
                          .ToListAsync();
        }
    }
}
