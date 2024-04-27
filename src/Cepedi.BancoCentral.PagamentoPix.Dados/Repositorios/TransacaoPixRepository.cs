using Cepedi.BancoCentral.PagamentoPix.Data;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;
public class TransacaoPixRepository : ITransacaoPixRepository
{

    private readonly ApplicationDbContext _context;

    public TransacaoPixRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<TransacaoPixEntity> AtualizarTransacaoPixAsync(TransacaoPixEntity transacao)
    {
        throw new NotImplementedException();
    }

    public async Task<TransacaoPixEntity> CriarTransacaoPixAsync(TransacaoPixEntity transacao)
    {
        _context.TransacaoPix.Add(transacao);

        await _context.SaveChangesAsync();

        return transacao;
    }

    public async Task<TransacaoPixEntity> ObterTransacaoPixAsync(int IdTransacaoPix)
    {
        return await _context.TransacaoPix.Where(p => p.IdTransacaoPix == IdTransacaoPix).FirstOrDefaultAsync();
    }
}
