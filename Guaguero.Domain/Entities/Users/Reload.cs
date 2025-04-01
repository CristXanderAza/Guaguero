using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Sindicatos;

namespace Guaguero.Domain.Entities.Users
{
    public class Reload : AuditEntity
    {
        public Guid ReloadID { get; set; }
        public decimal Amount { get; set; }
        public Guid CreditID { get; set; }
        public virtual CreditPerUser CreditPerUser { get; set; }
    }
}
