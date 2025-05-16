using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class TipoBicicleta
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Bicicleta> Bicicletas { get; set; }
    }
}