using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.PagamentoPix.Data.Repositories;

public class ContaRepository : IContaRepository
{
    private readonly ApplicationDbContext _context;
    public ContaRepository(ApplicationDbContext context) => _context = context;
    public async Task<ContaEntity> ObterContaByIdAsync(int idConta)
    {
        return await _context.Contas.Where(x => x.IdConta == idConta).FirstOrDefaultAsync();
    }
}