using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.DTOs.CrearDTOs
{
    public class CrearAtencionDTO
    {
        public string Motivo { get; set; }
        public string Tratamiento { get; set; }
        public string? Medicamentos { get; set; }
        public DateTime? Fecha { get; set; }

        public int AnimalId { get; set; }
    }
}
