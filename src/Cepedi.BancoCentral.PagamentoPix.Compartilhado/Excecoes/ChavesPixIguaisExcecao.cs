using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
public class ChavesPixIguais : ExcecaoAplicacao
{
    public ChavesPixIguais() : 
        base(PagamentosPix.ChavesPixIguais)
    {
    }
}
