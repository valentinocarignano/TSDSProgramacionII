using CEntidades.Entities;

namespace CEntidades.DTOs.RespuestaDTOs
{
    public class AtencionDTO
    {
        public int ID { get; set; }
        public string Motivo { get; set; }
        public string Tratamiento { get; set; }
        public string? Medicamentos { get; set; }
        public DateTime? Fecha { get; set; }

        public int AnimalId { get; set; }
    }
}