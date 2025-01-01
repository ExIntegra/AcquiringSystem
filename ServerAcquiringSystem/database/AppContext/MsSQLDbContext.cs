using InterFaceModul.database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceModul.database.AppContext
{
    // EntityFrameWork в БД Microsoft SQL . 
    // Просто для примера....
    // А так - это "заглушка"
    internal class MsSQLDbContext : DbContext
    {
        public DbSet<Person> persons { get; set; }// => Set<Person>();

        public MsSQLDbContext()
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
