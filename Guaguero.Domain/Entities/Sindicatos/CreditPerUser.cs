using Guaguero.Domain.Entities.Travels.Payments;
using Guaguero.Domain.Entities.Users;

namespace Guaguero.Domain.Entities.Sindicatos
{
    public class CreditPerUser
    {

        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; } 
        public virtual ICollection<Reload> Reloads { get; set; }
        public virtual ICollection<PaymentBase> Payments { get; set; }
    }
}
