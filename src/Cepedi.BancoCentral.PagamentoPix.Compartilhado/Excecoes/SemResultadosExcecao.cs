using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
public class SemResultadosExcecao : ExcecaoAplicacao
{
    public SemResultadosExcecao() : 
        base(PagamentosPix.SemResultados)
    {
    }
}
