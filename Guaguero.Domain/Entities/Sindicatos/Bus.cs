using Guaguero.Domain.Base;
using Guaguero.Domain.Entities.Travels;

namespace Guaguero.Domain.Entities.Sindicatos
{
    public class Bus: AuditEntity
    {
        public int BusID { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public bool IsActive { get; set; }
        public int Capacidad { get; set; }
        public string Estado { get; set; }
        public int SindicatoID { get; set; }
        public Sindicato Sindicato { get; set; }
        public virtual ICollection<Travel> Travels { get; set; }
    }
}
