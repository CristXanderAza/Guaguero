using Guaguero.Domain.Entities.Logistic.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Domain.Utils
{
    public static class GeoUtils
    {
        public static double Haversine(Coordinate coordinateA, Coordinate coordinateB)
        {
            double lat1 = coordinateA.Lat;
            double lon1 = coordinateA.Lng;
            double lat2 = coordinateB.Lat;
            double lon2 = coordinateB.Lng;

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
