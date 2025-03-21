using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Domain.Entities.Travels.Payments
{
    public class EfectivePayment : PaymentBase
    {
        public decimal TotalPaid { get; set; }
        public decimal Devolution { get; set; }

    }
}
