using Guaguero.Domain.Base;

namespace Guaguero.Domain.Entities.Travels.Payments
{
    public abstract class PaymentBase : AuditEntity
    {
        public Guid PaymentID { get; set; }
        public decimal Amount { get; set; }
        public bool Accepted { get; set; }
        public Guid QuotaID { get; set; }
        public virtual Quota Quota { get; set; }
    }
}
