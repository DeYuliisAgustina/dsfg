using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Modelo
{
    public class Context : DbContext
    {
        private static Context instancia;
        public static Context Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new Context();
                return instancia;
            }
        }

        public DbSet<Universidad> Universidades { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Computadora> Computadoras { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.EnableSensitiveDataLogging(true);
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SistemaGestion;Trusted_Connection=True;");
        }

    }
}
