using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Logistic.Routes;
using Guaguero.Domain.Entities.Sindicatos;
using Guaguero.Domain.Entities.Users;

namespace Guaguero.Domain.Entities.Travels
{
    public class Travel : AuditEntity
    {
        public Guid TravelID { get; set; }
        public int RouteID { get; set; }
        public Route Route { get; set; }
        public Guid BusID { get; set; }
        public Bus Bus { get; set; }
        public Guid EmpleoyeeID { get; set; }
        public Employee Employee { get; set; }
        public DateTime Departure { get; set; }
        public int InformalQuotas { get; set; }
        public int Exits { get; set; }
        public DateTime Arrival { get; set; }
        public Coordinate ActualLocation { get; set; }
        public TravelState Status { get; set; }
        public virtual ICollection<Quota> Quotas { get; set; }
        public int SeetsDisponibles 
            => Bus.Capacidad - Quotas.Where(q => q.Status != QuotaState.Canceled).Count() - 
               (InformalQuotas - Exits);
       /*
        public virtual ICollection<TravelStop> Stops { get; set; }
        public Guid NextStopID { get; set; }
        public virtual TravelStop NextStop { get; set; }
       */
        public int ActualStep {  get; set; }

        public Travel()
        {
            //Stops = new List<TravelStop>();
        }
        /*
        public TravelStop GetNextStop(Coordinate busCoordinate)
        {
            var puntoMasCercano = Stops
                .OrderBy(c => Haversine(busCoordinate.Lat, busCoordinate.Lng, c.Coordinate.Lat, c.Coordinate.Lng))
                .First();
            NextStopID = puntoMasCercano.TravelStopID;
            NextStop = puntoMasCercano;
            return NextStop;

        }
        */
        static double Haversine(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Radio de la Tierra en km
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }

        static double ToRadians(double deg) => deg * Math.PI / 180;
    }
}

