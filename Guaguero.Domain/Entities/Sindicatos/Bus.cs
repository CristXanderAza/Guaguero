﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Guid SindicatoID { get; set; }
        public Sindicato Sindicato { get; set; }
    }
}
