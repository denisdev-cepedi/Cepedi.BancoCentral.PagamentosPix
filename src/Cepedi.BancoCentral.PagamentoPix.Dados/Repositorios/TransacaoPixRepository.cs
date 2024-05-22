using System.Linq.Expressions;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
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

        return transacao;
    }

    public async Task<string> ObterChavePixPorIdAsync(int id)
    {
        var pix = await _context.Pix.SingleOrDefaultAsync(p => p.IdPix == id);
        return pix?.ChavePix;
    }

    public async Task<int> ObterIdPorChavePixAsync(string chavePix)
    {
        var pix = await _context.Pix.SingleOrDefaultAsync(p => p.ChavePix == chavePix);
        Console.WriteLine(pix);
        return pix?.IdPix ?? 0;
    }

    public async Task<TransacaoPixEntity> ObterTransacaoPixAsync(int IdTransacaoPix)
    {
        return await _context.TransacaoPix.Where(p => p.IdTransacaoPix == IdTransacaoPix).FirstOrDefaultAsync();
    }

    public async Task<List<TransacaoPixEntity>> ObterTransacoesPixAsync()
    {
        return await _context.TransacaoPix.ToListAsync();
    }

    public async Task<List<TransacaoPixEntity>> ObterTransacoesPixFilterAsync(ObterTransacaoPixRequestFilter filter)
    {
         Expression <Func<TransacaoPixEntity, bool>> dataFilter = p =>p.Data >= filter.DataInicial && p.Data <= filter.DataFinal;
        _context.TransacaoPix.Where(dataFilter);
        return await _context.TransacaoPix.ToListAsync();
    }

    public async  Task<List<TransacaoPixEntity>> ObterTransacoesPixPorChavePixAsync(int idPixOrigem)
    {
        return await _context.TransacaoPix
            .Where(t => t.IdPixOrigem == idPixOrigem)
            .ToListAsync();
    }
}
