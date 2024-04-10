using Cepedi.BancoCentral.PagamentoPix.Shareable.Enums;

namespace Cepedi.BancoCentral.PagamentoPix.Shareable.Exceptions;
public class SemResultadosException : ApplicationException
{
    public SemResultadosException() : 
        base(BancoCentralMensagemErrors.SemResultados)
    {
    }
}
