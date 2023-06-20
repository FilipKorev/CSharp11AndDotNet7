using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LinqWithEFCore
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null;
        public DbSet<Product> Products { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "DataBase", "Northwind.db");

            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if ((Database.ProviderName is not null) && (Database.ProviderName.Contains("Sqlite")))
            {
                modelBuilder.Entity<Product>()
                    .Property(p => p.UnitPrice)
                    .HasConversion<double>();
            }
        }

    }
}
