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
        }
    }
}
