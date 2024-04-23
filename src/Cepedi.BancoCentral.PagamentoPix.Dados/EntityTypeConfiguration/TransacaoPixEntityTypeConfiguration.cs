using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.PagamentoPix.Data.EntityTypeConfiguration;
public class TransacaoPixEntityTypeConfiguration : IEntityTypeConfiguration<TransacaoPixEntity>
{
    public void Configure(EntityTypeBuilder<TransacaoPixEntity> builder)
    {
        builder.ToTable("TransacaoPix"); 

        builder.HasKey(c => c.Id); 

        builder.Property(c => c.Valor).IsRequired(); 
        builder.Property(c => c.Data).IsRequired(); 
        builder.Property(c => c.ChavePix).IsRequired(); 
        builder.Property(c => c.ChaveDeSeguranca).IsRequired(); 
        builder.Property(c => c.IdContaOrigem).IsRequired(); 
        builder.Property(c => c.IdContaDestino).IsRequired();
        
        builder.HasOne<ContaEntity>()
            .WithMany()
            .HasForeignKey(t => t.IdContaOrigem)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PixEntity>()
            .WithMany()
            .HasForeignKey(t => t.IdContaDestino)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
