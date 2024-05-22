using Cepedi.BancoCentral.PagamentoPix.Dominio;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio.Queries;

public interface ITransacaoPixQueryRepository
{
    Task<List<TransacaoPixEntity>> ObterTransacaoPixAsync(string nome);
}