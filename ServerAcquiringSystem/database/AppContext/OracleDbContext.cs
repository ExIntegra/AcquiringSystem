using InterFaceModul.database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceModul.database.AppContext
{
    // EntityFrameWork в БД Oracle 
    // Просто для примера....
    // А так - это "заглушка"
    public class OracleDbContext:DbContext
    {
        public DbSet<Person> persons { get; set; }// => Set<Person>();

        public OracleDbContext()
        {

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"User Id=blog;Password=<password>;Data Source=pdborcl;");
        }
    }
}
