using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.PagamentoPix.Data.EntityTypeConfiguration;

public class ContaEntityTypeConfiguration : IEntityTypeConfiguration<ContaEntity>
{
    public void Configure(EntityTypeBuilder<ContaEntity> builder)
    {
        builder.ToTable("Conta");
        builder.HasKey(c => c.IdConta); // Define a chave primária 
        builder.Property(c => c.IdPessoa).IsRequired();
        builder.Property(c => c.Numero).IsRequired();
        builder.Property(c => c.Agencia).IsRequired();

        builder.HasOne(c => c.Pessoa)
                  .WithMany(p => p.Contas)
                  .HasForeignKey(c => c.IdPessoa).IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(conta => conta.Pixs)
                .WithOne(pix => pix.Conta)
                .HasForeignKey(pix => pix.IdConta)
                .OnDelete(DeleteBehavior.Restrict);

    }
}
