using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Application.DTOs.Travel
{
    public class ArrivalDTO
    {
        public Guid Id { get; set; }
        public Guid TravelID { get; set; }
        public bool IsPaid { get; set; }
        public decimal Total {  get; set; }
        public int seets { get; set; }
    }
}
