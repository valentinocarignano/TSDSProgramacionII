using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ConsolaModificarAnimalDTO
    {
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimineto { get; set; }
        public int? IDDuenio { get; set; }
    }
}