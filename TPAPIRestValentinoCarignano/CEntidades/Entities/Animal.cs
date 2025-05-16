namespace CEntidades.Entities
{
    public class Animal : EntityBase
    {
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }

        public Tipo Tipo { get; set; }
        public Duenio? Duenio { get; set; }
        public ICollection<Atencion> Atenciones { get; set;}
    }
}