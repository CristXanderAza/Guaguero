using Guaguero.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Domain.Entities.Sindicatos
{
    public class CreditPerUser
    {
        public int SindicatoID { get; set; }
        public Sindicato Sindicato { get; set; }
        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
        public decimal Credit { get; set; } 
    }
}
