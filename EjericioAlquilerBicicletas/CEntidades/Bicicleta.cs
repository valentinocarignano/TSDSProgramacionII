namespace CEntidades
{
    public class Bicicleta
    {
        public int ID { get; set; }
        public string Modelo { get; set; }
        public string Estado { get; set; }
        public string EstacionActual { get; set; }
        public double PrecioHora { get; set; }
        
        public TipoBicicleta TipoBicicleta { get; set; }
        public MarcaBicicleta MarcaBicicleta { get; set; }
        public Estacion Estacion { get; set; }
        public ICollection<Alquiler> Alquileres { get; set; }
    }
}