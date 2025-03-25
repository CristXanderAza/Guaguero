using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Entities.Travels.Payments;
using Guaguero.Domain.Entities.Users;

namespace Guaguero.Application.Commands.Travels.PaymentStrategies
{
    public interface IPayStrategy
    {
        Task<Result<PaymentBase>> MakePay(Travel travel, Customer customer, int seats);
    }
}
