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



    public async Task<TransacaoPixEntity> CriarTransacaoPixAsync(TransacaoPixEntity transacao)
    {
        _context.TransacaoPix.Add(transacao);

        await _context.SaveChangesAsync();

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

    public async Task<TransacaoPixEntity> ObterIdPorChaveSegurancaAsync(string chaveSeguranca)
    {
        return await _context.TransacaoPix
                        .Include(p => p.PixOrigem)
                        .Include(p => p.PixDestino)
                        .Where(p => p.ChaveDeSeguranca == chaveSeguranca)
                        .FirstOrDefaultAsync();
    }

    public async Task<TransacaoPixEntity> ObterTransacaoPixAsync(int IdTransacaoPix)
    {
        return await _context.TransacaoPix
     .Include(p => p.PixOrigem)
     .Include(p => p.PixDestino)
     .Where(p => p.IdTransacaoPix == IdTransacaoPix)
     .FirstOrDefaultAsync();

    }

    public async Task<List<TransacaoPixEntity>> ObterTransacoesPixAsync()
    {
        return await _context.TransacaoPix
        .Include(p => p.PixOrigem)  // Inclui a entidade de origem relacionada
        .Include(p => p.PixDestino) // Inclui a entidade de destino relacionada
        .ToListAsync();    
    }

    public async Task<List<TransacaoPixEntity>> ObterTransacoesPixFilterAsync(ObterTransacaoPixRequestFilter filter)
    {
        Expression<Func<TransacaoPixEntity, bool>> dataFilter = p => p.Data >= filter.DataInicial && p.Data <= filter.DataFinal;

        var transacoes = await _context.TransacaoPix
            .Include(p => p.PixOrigem)  // Inclui a entidade Origem relacionada
            .Include(p => p.PixDestino) // Inclui a entidade Destino relacionada
            .Where(dataFilter)       // Aplica o filtro de data
            .ToListAsync();          // Executa a consulta e obtém os resultados

        return transacoes;

    }

    public async Task<List<TransacaoPixEntity>> ObterTransacoesPixPorChavePixAsync(string chavePix)
    {
        return await _context.TransacaoPix.Include(t => t.PixOrigem).Include(t => t.PixDestino)
            .Where(t => t.PixOrigem.ChavePix == chavePix)
            .ToListAsync();
    }
}
