using Guaguero.Domain.Entities.Sindicatos;

namespace Guaguero.Domain.Entities.Travels.Payments
{
    public class CreditPayment : PaymentBase
    {
        //public string AccountNumber { get; set; }
        public Guid CreditPerUserID { get; set; }
        public virtual CreditPerUser CreditPerUser { get; set; }
    }
}
