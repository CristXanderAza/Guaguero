using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Sindicatos;
using Guaguero.Domain.Entities.Travels;

namespace Guaguero.Domain.Entities.Logistic.Routes
{
    public class Route : AuditEntity
    {
        public int RouteID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public Coordinate? OriginPoint { get; set; }
        public string Destination { get; set; }
        public Coordinate? DestinationPoint { get; set; }
        public string GeoJSON { get; set; }
        //public string Polyline { get; set; }
        public double Distance { get; set; }
        public double Duration { get; set; }
       //public virtual ICollection<RouteSegement> Segments { get; set; }
        public virtual ICollection<WayPoint> WayPoints { get; set; }

        public virtual ICollection<Sindicato> Sindicatos { get; set; }

        public virtual ICollection<Travel> Travels { get; set; }

        public Route()
        {
            
        }
        

    }
}
