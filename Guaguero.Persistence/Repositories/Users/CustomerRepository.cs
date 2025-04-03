using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Entities.Users;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Users;
using Guaguero.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Repositories.Users
{
    public class CustomerRepository : BaseRepository<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(GuagueroContext context) : base(context)
        {
        }

        public override async Task<Customer> FindById(Guid guid)
        {
            return await _context.Customers.Include(c => c.Credit)
                .Include(c => c.Discount)
                .FirstOrDefaultAsync(c => c.UserID == guid);
        }
    }
}
