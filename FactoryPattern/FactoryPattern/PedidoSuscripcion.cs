using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class PedidoSuscripcion : IPedido
    {
        public void Procesar()
        {
            Console.WriteLine("Procesando suscripción: activando acceso y programando renovaciones.");
        }
    }
}