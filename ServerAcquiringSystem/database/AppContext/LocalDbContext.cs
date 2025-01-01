using InterFaceModul.database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace InterFaceModul.database.AppContext
{
    // EntityFrameWork с локальной БД, реализованной в Visual studio
    public class LocalDbContext : DbContext
    {
        public DbSet<Person> persons { get; set; }// => Set<Person>();

        public LocalDbContext()
        {

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");

        }
    }
}