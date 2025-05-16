using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ConsolaCrearAnimalDTO
    {
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimineto { get; set; }
        public int? IDDuenio { get; set; }
        public int IDTipo { get; set; }
    }
}
