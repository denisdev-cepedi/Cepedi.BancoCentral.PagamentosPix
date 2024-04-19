using System.Diagnostics.CodeAnalysis;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.PagamentoPix.Data;

[ExcludeFromCodeCoverage]
public class ApplicationDbContext : DbContext
{
    public DbSet<UsuarioEntity> Usuario { get; set; } = default!;

    public DbSet<ContaEntity> Conta { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
