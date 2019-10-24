using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TRC.Core.Modelo;

namespace TRC.Data.Configuration
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(e => e.Id_Estado);

            builder.Property(e => e.Sigla).HasMaxLength(2).IsRequired();

            builder.Property(e => e.Nome).IsRequired();
        }
    }
}
