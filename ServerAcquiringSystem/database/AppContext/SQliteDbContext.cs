using InterFaceModul.database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceModul.database.AppContext
{
    // EntityFrameWork для работы с БД SQLite
    internal class SQliteDbContext:DbContext
    {
        public DbSet<Person> persons { get; set; }// => Set<Person>();

        public SQliteDbContext()
        {

            //Database.EnsureDeleted();
            Database.EnsureCreated(); // 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Bank25.db");
        }
    }
}
