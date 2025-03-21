

namespace Guaguero.Domain.Entities.Sindicatos
{
    public class Bus
    {
        public Guid BusID { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int Capacidad { get; set; }
        public string Anio { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public int SindicatoID { get; set; }
        public Sindicato Sindicato { get; set; }
    }
}
