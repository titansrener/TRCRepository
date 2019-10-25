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

            builder.ToTable("TB_ESTADO");

            builder.Property(e => e.Sigla)
                .HasColumnName("Sigla")
                .HasMaxLength(2).IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("Nome")
                .IsRequired();
        }
    }
}
