using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Domain.Entities.Logistic.Routes
{
    public class RouteSegement
    {
        public Guid RouteID { get; set; }
        public int SegmentStep { get; set; }
        public Coordinate Start { get; set; }
        public Coordinate End { get; set; }
        public double Distance { get; set; }
        public string Polyline { get; set; }

        
        public bool IsInSegment(Coordinate userPoint)
        {
            var coordinates = DecodePolilyne();
            foreach (var coordinate in coordinates)
            {
                if (coordinate.Lat == userPoint.Lat && coordinate.Lng == userPoint.Lng)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Coordinate> DecodePolilyne()
        {
            string encoded = Polyline;
            List<Coordinate> polyline = new List<Coordinate>();
            int index = 0, len = encoded.Length;
            int lat = 0, lng = 0;

            while (index < len)
            {
                int b, shift = 0, result = 0;
                do
                {
                    b = encoded[index++] - 63;
                    result |= (b & 0x1F) << shift;
                    shift += 5;
                } while (b >= 0x20);

                int dlat = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
                lat += dlat;

                shift = 0;
                result = 0;
                do
                {
                    b = encoded[index++] - 63;
                    result |= (b & 0x1F) << shift;
                    shift += 5;
                } while (b >= 0x20);

                int dlng = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
                lng += dlng;

                polyline.Add(new Coordinate(lat / 1E5, lng / 1E5));
            }

            return polyline;
        }


        public static double DistanceBetweenPoints(Coordinate p1, Coordinate p2)
        {
            const double EarthRadius = 6371; // Radio de la Tierra en kilómetros

            double lat1Rad = DegreeToRadian(p1.Lat);
            double lon1Rad = DegreeToRadian(p1.Lng);
            double lat2Rad = DegreeToRadian(p2.Lat);
            double lon2Rad = DegreeToRadian(p2.Lng);

            double dlat = lat2Rad - lat1Rad;
            double dlon = lon2Rad - lon1Rad;

            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) + Math.Cos(lat1Rad) * Math.Cos(lat2Rad) * Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EarthRadius * c; // Distancia en kilómetros
        }
        public static double DegreeToRadian(double degree)
        {
            return degree * Math.PI / 180.0;

        }
    }
}
