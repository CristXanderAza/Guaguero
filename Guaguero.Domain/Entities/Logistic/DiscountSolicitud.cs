using Guaguero.Domain.Base;

namespace Guaguero.Domain.Entities.Logistic
{
    public class DiscountSolicitud : AuditEntity
    {
        public int DiscountID { get; set; }
        public int SolicitudID { get; set; }
        public virtual Discount Discount { get; set; }
        public DiscountSolicitudState State { get; set; }
    }
}
