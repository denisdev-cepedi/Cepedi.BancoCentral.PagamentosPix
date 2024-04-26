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

        builder.Property(pix => pix.ChavePix).IsRequired().HasMaxLength(32);
        builder.Property(pix => pix.IdTipoPix).IsRequired();
        builder.Property(pix => pix.DataCriacao).IsRequired();

        builder.HasOne(p => p.Conta)
                .WithMany(c => c.Pixs)
                .HasForeignKey(p => p.IdConta).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(pix => pix.TransacoesPixsEnviadas)
                .WithOne(transacao => transacao.PixOrigem)
                .HasForeignKey(transacao => transacao.IdPixOrigem)
                 .OnDelete(DeleteBehavior.Restrict);

                builder.HasMany(pix => pix.TransacoesPixsRecebidas)
                .WithOne(transacao => transacao.PixDestino)
                .HasForeignKey(transacao => transacao.IdPixDestino)
                .OnDelete(DeleteBehavior.Restrict);


    }
}
