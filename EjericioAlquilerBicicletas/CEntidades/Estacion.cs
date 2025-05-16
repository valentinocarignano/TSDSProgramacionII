using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class Estacion
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public int BicicletasDisponibles { get; set; }
        public int CapacidadMaxima { get; set; }

        public ICollection<Alquiler> AlquileresOrigen { get; set; }
        public ICollection<Alquiler> AlquileresDestino { get; set; }
        public ICollection<Bicicleta> Bicicletas { get; set; }
    }
}
