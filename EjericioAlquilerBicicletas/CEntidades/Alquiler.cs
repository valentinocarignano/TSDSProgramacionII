using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class Alquiler
    {
        public int ID { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public TimeSpan Duracion { get; set; }
        public double MontoTotal { get; set; }

        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public Bicicleta Bicicleta { get; set; }
        public Estacion EstacionOrigen { get; set; }
        public Estacion EstacionDestino { get; set; }
    }
}
