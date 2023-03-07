using Microsoft.EntityFrameworkCore;
using WebApiEstadios.Entidades;

namespace WebApiEstadios
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }

    }
}
