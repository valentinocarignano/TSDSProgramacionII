namespace CEntidades.Entities
{
    public class Tipo : EntityBase
    {
        public string Descripcion { get; set; }

        public ICollection<Animal> Animales { get; set; }
    }
}