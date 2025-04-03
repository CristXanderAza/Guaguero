namespace Guaguero.Domain.Entities.Logistic.Routes
{
    public class Coordinate
    {
        public double Lat { get; set; }
        public double Lng { get; set; }

        public Coordinate(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        public Coordinate() { }
    }
}
