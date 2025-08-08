using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class PedidoFactory
    {
        // Método estático que actúa como la fábrica
        public static IPedido CrearPedido(string tipoProducto)
        {
            if (tipoProducto == "Fisico")
            {
                return new PedidoFisico();
            }
            else if (tipoProducto == "Digital")
            {
                return new PedidoDigital();
            }
            else if (tipoProducto == "Suscripcion")
            {
                return new PedidoSuscripcion();
            }
            else if (tipoProducto == "Regalo")
            {
                return new PedidoRegalo();
            }
            else { throw new ArgumentException("Tipo de producto no válido."); }
        }
    }
}