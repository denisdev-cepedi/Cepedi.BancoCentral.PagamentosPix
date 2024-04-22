using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.PagamentoPix.Data.EntityTypeConfiguration;
public class PixEntityTypeConfiguration : IEntityTypeConfiguration<PixEntity>
{
    public void Configure(EntityTypeBuilder<PixEntity> builder)
    {
        builder.ToTable("Pix");
        builder.HasKey(pix => pix.IdPix); // Define a chave primária

        builder.Property(pix => pix.IdConta).IsRequired();
        builder.Property(pix => pix.IdPessoa).IsRequired();


        builder.Property(pix => pix.ChavePix).IsRequired().HasMaxLength(32);
        builder.Property(pix => pix.IdTipoPix).IsRequired();
        builder.Property(pix => pix.DataCriacao).IsRequired();
        builder.HasOne(p => p.Conta).WithMany(c => c.Pixs).HasForeignKey(p => p.IdConta).IsRequired();

    }
}
