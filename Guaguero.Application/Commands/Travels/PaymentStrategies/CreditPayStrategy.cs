using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Entities.Travels.Payments;
using Guaguero.Domain.Entities.Users;

namespace Guaguero.Application.Commands.Travels.PaymentStrategies
{
    public class CreditPayStrategy : IPayStrategy
    {
        public async Task<Result<PaymentBase>> MakePay(Travel travel, Customer customer, int seats)
        {
            decimal total = travel.PricePerSeat * seats;
            total -= total * (customer.Discount.Percentage / 100);
            decimal credit = customer.Credit.Amount;
            if (credit < total)
                return Result<PaymentBase>.Fail("Creditos del cliente insuficientes para realizar el pago");
            PaymentBase payment = new CreditPayment()
            {
                Amount = total
            };
            customer.Credit.Amount -= total;
            return Result<PaymentBase>.Success(payment);
        }
    }
}
