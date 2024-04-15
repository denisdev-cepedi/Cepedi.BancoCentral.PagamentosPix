using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
public class RequestInvalidaExcecao : ExcecaoAplicacao
{
    public RequestInvalidaExcecao(IDictionary<string, string[]> erros)
        : base(PagamentosPix.DadosInvalidos) =>
        Erros = erros.Select(e => $"{e.Key}: {string.Join(", ", e.Value)}");

    public IEnumerable<string> Erros { get; }
}
