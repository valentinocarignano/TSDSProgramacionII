using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class PedidoRegalo : IPedido
    {
        public void Procesar()
        {
            Console.WriteLine("Procesando pedido regalo: envolviendo y agregando tarjeta personalizada.");
        }
    }
}
