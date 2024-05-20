using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
public class PixInexistente : ExcecaoAplicacao
{
    public PixInexistente() : 
        base(PagamentosPix.PixInexistente)
    {
    }
}
