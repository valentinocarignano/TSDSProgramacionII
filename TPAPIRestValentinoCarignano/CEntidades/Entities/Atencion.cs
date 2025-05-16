namespace CEntidades.Entities
{
    public class Atencion : EntityBase
    {
        public string Motivo { get; set; }
        public string Tratamiento { get; set; }
        public string? Medicamentos { get; set; }
        public DateTime? Fecha { get; set; }

        public Animal Animal { get; set; }
    }
}