using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Logistic.Routes;
using Guaguero.Domain.Entities.Travels.Payments;
using Guaguero.Domain.Entities.Users;

namespace Guaguero.Domain.Entities.Travels
{
    public class Quota : AuditEntity
    {
        public Guid QuotaID { get; set; }
        public Guid TravelID { get; set; }
        public virtual Travel Travel { get; set; }
        public Guid CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public int Quantity { get; set; }
        /*
        public Guid ArrivalStopID { get; set; }
        public virtual TravelStop ArrivalStop { get; set; }
        public Guid DepertureStopID { get; set; }
        public virtual TravelStop DepertureStop { get; set; }
        */
        public int EntryStep { get; set; }
        public decimal Total { get; set; }

        //public int WayPointID { get; set; }
        public virtual WayPoint? EntryPoint { get; set; }
        public Guid PaymentID { get; set; }
        public virtual PaymentBase Payment { get; set; }
        public QuotaState Status { get; set; }
    }
}
