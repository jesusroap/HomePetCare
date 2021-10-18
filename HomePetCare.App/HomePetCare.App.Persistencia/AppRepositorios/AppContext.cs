using Microsoft.EntityFrameworkCore;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Mascota> Mascotas {get; set;}
        public DbSet<Propietario> Propietarios {get; set;}
        public DbSet<Veterinario> Veterinarios {get; set;}
        public DbSet<Visita> Visitas {get; set;} 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {       
            if(!optionsBuilder.IsConfigured) 
            {   
                // Ejecutar en windows
                // optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HomePetCareData");

                // Ejecutar en mac
                var user = "SA";
                var pass = "";
                optionsBuilder.UseSqlServer("Server=localhost,1433\\MSSQLLocalDB;Initial Catalog=HomePetCareData2;User=" + user + ";Password=" + pass);
            }
        } 

    }

}