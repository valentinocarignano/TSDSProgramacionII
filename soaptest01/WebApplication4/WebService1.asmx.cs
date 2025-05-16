using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication4
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string ComparaNumeros(double num1, double num2)
        {
            string respuesta = string.Empty;

            if(num1 > num2)
            {
                respuesta = $"El primer numero ingresado ({num1}) es mayor.";
            }
            else if(num1 < num2)
            {
                respuesta = $"El segundo numero ingresado ({num2}) es mayor.";
            }
            else
            {
                respuesta = "Los numeros son iguales.";

            }

            return respuesta;
        }
    }
}
