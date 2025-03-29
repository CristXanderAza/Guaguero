using Guaguero.Domain.Base;

namespace Guaguero.Domain.Entities.Users
{
    public class Reload : AuditEntity
    {
        public decimal Amount { get; set; }
        public Guid CustomerID { get; set; }
    }
}
