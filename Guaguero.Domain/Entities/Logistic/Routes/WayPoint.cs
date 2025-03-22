using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Domain.Entities.Logistic.Routes
{
    public class WayPoint
    {
        public int WayPointID { get; set; }
        public Coordinate Coordinate { get; set; }
        public int RouteID { get; set; }
        public int StepIndex { get; set; }

    }
}
