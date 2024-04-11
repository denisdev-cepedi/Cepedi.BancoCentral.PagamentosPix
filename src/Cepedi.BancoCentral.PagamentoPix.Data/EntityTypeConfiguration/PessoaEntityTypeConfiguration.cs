using Cepedi.BancoCentral.PagamentoPix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.PagamentoPix.Data.EntityTypeConfiguration;


public class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<PessoaEntity>
{
    public void Configure(EntityTypeBuilder<PessoaEntity> builder)
    {
        builder.ToTable("Pessoas");
        builder.HasKey(pessoa => pessoa.IdPessoa); // Define a chave primária
        builder.Property(pessoa => pessoa.Nome).HasMaxLength(150);
        builder.Property(pessoa => pessoa.IdPessoa).IsRequired();
        builder.Property(pessoa => pessoa.Cpf).IsRequired().HasMaxLength(12);
        builder.Property(pessoa => pessoa.IdConta).IsRequired();
    }
}