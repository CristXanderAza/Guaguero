using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Logistic.Routes;
using Guaguero.Domain.Entities.Sindicatos;
using Guaguero.Domain.Entities.Users;

namespace Guaguero.Domain.Entities.Travels
{
    public class Travel : AuditEntity
    {
        public Guid TravelID { get; set; }
        public Guid RouteID { get; set; }
        public Route Route { get; set; }
        public Guid BusID { get; set; }
        public Bus Bus { get; set; }
        public Guid EmpleoyeeID { get; set; }
        public Employee Employee { get; set; }
        public DateTime Departure { get; set; }
        public int InformalQuotas { get; set; }
        public int InformalExits { get; set; }
        public DateTime Arrival { get; set; }
        public Coordinate ActualLocation { get; set; }
        public TravelState Status { get; set; }
        public virtual ICollection<Quota> Quotas { get; set; }
        public int SeetsDisponibles 
            => Bus.Capacidad - Quotas.Where(q => q.Status != QuotaState.Canceled).Count() - (InformalQuotas - InformalExits);
        public virtual ICollection<TravelStop> Stops { get; set; }
        public Guid NextStopID { get; set; }
        public virtual TravelStop NextStop { get; set; }
        public int ActualStep {  get; set; }

        public Travel()
        {
            Stops = new List<TravelStop>();
        }
    }
}
