using Guaguero.Domain.Entities.Users;

namespace Guaguero.Domain.Interfaces.PersistenceInterfaces.Users
{
    public interface ICustomerRepository : IRepositoryBase<Customer, Guid>
    {
    }
}
