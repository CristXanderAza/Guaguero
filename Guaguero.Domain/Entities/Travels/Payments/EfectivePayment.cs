

namespace Guaguero.Domain.Entities.Travels.Payments
{
    public class EfectivePayment : PaymentBase
    {
        public decimal TotalPaid { get; set; }
        public decimal Devolution { get; set; }

    }
}
