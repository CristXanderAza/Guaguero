﻿using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Logistic.Routes;


namespace Guaguero.Domain.Entities.Travels
{
    public class TravelStop : AuditEntity
    {
        public Guid TravelStopID { get; set; }
        public int WayPointID { get; set; }
        public WayPoint WayPoint { get; set; }   
        public Coordinate Coordinate
            => WayPoint.Coordinate;
        public StopType Type { get; set; }
        public bool Passed { get; set; }
        public DateTime PassedAt { get; set; }
        public Guid TravelID { get; set; }
    }
}
