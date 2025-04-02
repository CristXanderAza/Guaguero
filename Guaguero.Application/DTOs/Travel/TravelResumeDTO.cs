using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Application.DTOs.Travel
{
    public class TravelResumeDTO
    {
        public Guid TravelID { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Step { get; set; }
        public string StepState { get; set; }
        public int DisponiblesSteats { get; set; }

    }
}
