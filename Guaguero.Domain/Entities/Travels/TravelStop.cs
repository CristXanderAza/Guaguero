using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Logistic.Routes;


namespace Guaguero.Domain.Entities.Travels
{
    public class TravelStop : AuditEntity
    {
        public Guid TravelStopID { get; set; }
        public Coordinate Point { get; set; }
        public StopType Type { get; set; }
        public bool Passed { get; set; }
        public DateTime PassedAt { get; set; }
    }
}
