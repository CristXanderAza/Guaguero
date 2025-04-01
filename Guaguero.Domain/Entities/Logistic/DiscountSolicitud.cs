using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Users;

namespace Guaguero.Domain.Entities.Logistic
{
    public class DiscountSolicitud : AuditEntity
    {
        public int DiscountID { get; set; }
        public int SolicitudID { get; set; }
        public Guid CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Discount Discount { get; set; }
        public DiscountSolicitudState State { get; set; }
    }
}
