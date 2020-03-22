using Domain.Map;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.DAL
{
    public class TaxaJurosContext : DbContext
    {
        public TaxaJurosContext(DbContextOptions options) : base(options) { }

        public TaxaJurosContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("dbInMemory");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TaxaJurosMap());
        }

        public virtual DbSet<TaxaJuros> TaxaJuros { get; set; }
    }
}
