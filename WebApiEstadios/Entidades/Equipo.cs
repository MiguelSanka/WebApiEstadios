namespace WebApiEstadios.Entidades
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int EstadioId { get; set; }

        public Estadio Estadio { get; set; }
    }
}
