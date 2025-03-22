using Guaguero.Domain.Base;

namespace Guaguero.Domain.Entities.Logistic.Routes
{
    public class Route : AuditEntity
    {
        public int RouteID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public Coordinate OriginPoint { get; set; }
        public string Destination { get; set; }
        public Coordinate DestinationPoint { get; set; }
        public string URL { get; set; }
        //public string Polyline { get; set; }
        public double Distance { get; set; }
        public double Duration { get; set; }
       //public virtual ICollection<RouteSegement> Segments { get; set; }
        public virtual ICollection<WayPoint> WayPoints { get; set; }

        public Route()
        {
            //Segments = new List<RouteSegement>();
        }
        /*
        public Result<Coordinate> FindStopPoint(Coordinate userPoint)
        {
            RouteSegement? nearestSegment = FindNearestSegment(userPoint, 1000);
            IEnumerable<Coordinate> coordinates = nearestSegment.DecodePolilyne();
            Coordinate stop = coordinates.FirstOrDefault(c => GetDistance(c, userPoint) < 50);
            return (stop != null)? Result<Coordinate>.Success(stop) : Result<Coordinate>.Fail("No se encontró un punto de parada cercano");
        }

        public RouteSegement? FindNearestSegment(Coordinate userPoint, double radius)
        {
            return Segments.FirstOrDefault(segment =>
                                                GetDistance(userPoint, segment.Start) < radius ||
                                                GetDistance(userPoint, segment.End) < radius
                                            );
        }

        private  double GetDistance(Coordinate p1, Coordinate p2)
        {
            double R = 6371000; // Radio de la Tierra en metros
            double dLat = (p2.Lat - p1.Lat) * Math.PI / 180;
            double dLon = (p2.Lng - p1.Lng) * Math.PI / 180;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(p1.Lat * Math.PI / 180) * Math.Cos(p2.Lat * Math.PI / 180) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c; // Distancia en metros
        }
        */
    }
}
