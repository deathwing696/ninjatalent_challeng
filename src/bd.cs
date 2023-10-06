using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Data.Entity;

namespace deathwing696
{
    public class Bd : DbContext
    {
        public Bd() : base("InMemoryConnection")
        {
        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasKey(c => c.Alpha2Code);

            modelBuilder.Entity<Country>()
                .Property(c => c.Name);
           
            modelBuilder.Entity<Country>()
                .Property(c => c.Alpha3Code);

            modelBuilder.Entity<Country>()
                .Property(c => c.Capital);

            modelBuilder.Entity<Country>()
                .Property(c => c.Region);

            modelBuilder.Entity<Country>()
                .Property(c => c.NativeName);

            base.OnModelCreating(modelBuilder);
        }
    }
}
