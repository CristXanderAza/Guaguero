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
        public Guid ArrivalStopID { get; set; }
        public TravelStop ArrivalStop { get; set; }
        public Guid DepertureStopID { get; set; }
        public TravelStop DepertureStop { get; set; }
        public QuotaState Status { get; set; }
    }
}
