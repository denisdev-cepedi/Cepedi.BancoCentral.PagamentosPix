using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;

public interface ITransacaoPixRepository
{
    Task<TransacaoPixEntity> CriarTransacaoPixAsync(TransacaoPixEntity transacao);
    Task<TransacaoPixEntity> ObterTransacaoPixAsync(int id);
    Task<List<TransacaoPixEntity>> ObterTransacoesPixAsync();
    Task<List<TransacaoPixEntity>> ObterTransacoesPixFilterAsync(ObterTransacaoPixRequestFilter filter);
    Task<TransacaoPixEntity> AtualizarTransacaoPixAsync(TransacaoPixEntity transacao);
}
