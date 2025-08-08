using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class PedidoDigital : IPedido
    {
        public void Procesar()
        {
            Console.WriteLine("Procesando pedido digital: enviando email con enlace de descarga.");
        }
    }
}