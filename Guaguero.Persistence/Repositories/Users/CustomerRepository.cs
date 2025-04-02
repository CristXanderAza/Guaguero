using Guaguero.Domain.Entities.Users;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Users;
using Guaguero.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Repositories.Users
{
    public class CustomerRepository : BaseRepository<Customer, Guid>, ICustomerRepository
    {
        protected CustomerRepository(GuagueroContext context) : base(context)
        {
        }
    }
}
