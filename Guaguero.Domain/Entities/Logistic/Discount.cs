
using Guaguero.Domain.Base;

namespace Guaguero.Domain.Entities.Logistic
{
    public class Discount : AuditEntity
    {
        public int DiscountID { get; set; }
        public int Percentage { get; set; }
        public string Description { get; set; }
    }
}
