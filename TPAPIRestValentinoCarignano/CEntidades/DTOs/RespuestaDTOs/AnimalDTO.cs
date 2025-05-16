namespace CEntidades.DTOs.RespuestaDTOs
{
    public class AnimalDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string DescripcionTipo { get; set; }
        public string Raza { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimineto { get; set; }
        public int? DNIDuenio { get; set; }
    }
}
