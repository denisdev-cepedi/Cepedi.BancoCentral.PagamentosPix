using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
public class CriarTransacaoPixRequest : IRequest<Result<CriarTransacaoPixResponse>>
{
    public double Valor { get; set; }

    public DateTime Data { get; set; }

    public string ChavePix { get; set; }
    public string ChaveDeSeguranca { get; set; }

    public int IdPixOrigem { get; set; }

    public int IdPixDestino { get; set; }
}
