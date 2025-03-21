namespace Guaguero.Domain.Entities.Logistic.Routes
{
    public struct Coordinate
    {
        public double Lat;
        public double Lng;

        public Coordinate(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }
    }
}
