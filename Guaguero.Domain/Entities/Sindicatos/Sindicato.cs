using Guaguero.Domain.Base;


namespace Guaguero.Domain.Entities.Sindicatos
{
    public class Sindicato : AuditEntity
    {
        public int SindicatoID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Bus> Buses { get; set; }
    }
}
