using AppSqlLite.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Xamarin.Essentials;

namespace AppSqlLite.Data
{
    public class PersonaContext:DbContext
    {
        public DbSet<PersonaModel> TBPersona { get; set; }
        public PersonaContext()
        {
            //Solo necesario para iniciar SQLite en iOS
            SQLitePCL.Batteries_V2.Init();

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "PersonaDB.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
