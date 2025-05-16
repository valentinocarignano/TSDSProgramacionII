namespace CEntidades.Entities
{
    public class Duenio : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }

        public ICollection<Animal> Animales { get; set; }
    }
}