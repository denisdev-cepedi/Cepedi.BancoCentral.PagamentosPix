using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.PagamentoPix.Data.EntityTypeConfiguration;


public class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<PessoaEntity>
{
    public void Configure(EntityTypeBuilder<PessoaEntity> builder)
    {
<<<<<<< HEAD
         builder.ToTable("Pessoas");
=======
        builder.ToTable("Pessoa");
>>>>>>> master
        builder.HasKey(pessoa => pessoa.IdPessoa); // Define a chave primária
        builder.Property(pessoa => pessoa.Nome).HasMaxLength(150);
        builder.Property(pessoa => pessoa.IdPessoa).IsRequired();
        builder.Property(pessoa => pessoa.Cpf).IsRequired().HasMaxLength(12);
        builder.HasMany(c => c.Contas)
                .WithOne(p => p.Pessoa)
                .HasForeignKey(p => p.IdPessoa).IsRequired();
    }
}
