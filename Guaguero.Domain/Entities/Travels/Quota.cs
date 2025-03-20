using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Logistic.Routes;
using Guaguero.Domain.Entities.Users;

namespace Guaguero.Domain.Entities.Travels
{
    public class Quota : AuditEntity
    {
        public Guid QuotaID { get; set; }
        public Guid TravelID { get; set; }
        public Travel Travel { get; set; }
        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
        public Coordinate ArrivedAt { get; set; }
        public DateTime ArrivedOn { get; set; }
        public Coordinate? DepartureAt { get; set; }
        public DateTime? DepartureOn { get; set; }
        public QuotaState Status { get; set; }
    }
}
