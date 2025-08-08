using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class PedidoFisico : IPedido
    {
        public void Procesar()
        {
            Console.WriteLine("Procesando físico: generando etiqueta de envío.");
        }
    }
}