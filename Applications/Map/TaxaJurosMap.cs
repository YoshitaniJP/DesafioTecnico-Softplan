using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Map
{
    public class TaxaJurosMap : IEntityTypeConfiguration<TaxaJuros>
    {
        public void Configure(EntityTypeBuilder<TaxaJuros> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                 new TaxaJuros
                 {
                     Id = 1,
                     ValorTaxa = 0.01m
                 });
        }
    }
}
