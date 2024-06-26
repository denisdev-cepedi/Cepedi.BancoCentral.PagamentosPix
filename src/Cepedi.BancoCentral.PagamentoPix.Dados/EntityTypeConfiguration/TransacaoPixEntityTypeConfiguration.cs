﻿using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.PagamentoPix.Data.EntityTypeConfiguration;
public class TransacaoPixEntityTypeConfiguration : IEntityTypeConfiguration<TransacaoPixEntity>
{
    public void Configure(EntityTypeBuilder<TransacaoPixEntity> builder)
    {
        builder.ToTable("TransacaoPix"); 

        builder.HasKey(c => c.IdTransacaoPix); 

        builder.Property(c => c.Valor).IsRequired(); 
        builder.Property(c => c.Data).IsRequired(); 
        builder.Property(c => c.ChaveDeSeguranca).IsRequired(); 
        builder.Property(c => c.IdPixOrigem).IsRequired(); 
        builder.Property(c => c.IdPixDestino).IsRequired();
        
    }
}
