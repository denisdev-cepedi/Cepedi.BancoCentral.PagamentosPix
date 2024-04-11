using Cepedi.BancoCentral.PagamentoPix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.PagamentoPix.Data.EntityTypeConfiguration;

public class ContaEntityTypeConfiguration : IEntityTypeConfiguration<ContaEntity>
{
    public void Configure(EntityTypeBuilder<ContaEntity> builder)
    {
        builder.ToTable("Contas");
        builder.HasKey(c => c.IdConta); // Define a chave primária 
        builder.Property(c => c.IdPessoa).IsRequired();
        builder.Property(c => c.Numero).IsRequired();
        builder.Property(c => c.Agencia).IsRequired();
        builder.Property(c => c.Conta).IsRequired();
    }
}
