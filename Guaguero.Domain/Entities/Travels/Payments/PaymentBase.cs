using Guaguero.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Domain.Entities.Travels.Payments
{
    public abstract class PaymentBase : AuditEntity
    {
        public Guid PaymentID { get; set; }
        public decimal Amount { get; set; }
        public bool Accepted { get; set; }
    }
}
