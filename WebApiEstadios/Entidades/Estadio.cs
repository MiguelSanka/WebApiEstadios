namespace WebApiEstadios.Entidades
{
    public class Estadio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Capacidad { get; set; } 

        public List<Equipo> Equipos { get; set;}
    }
}
