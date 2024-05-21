using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
public class CriarTransacaoPixRequest : IRequest<Result<CriarTransacaoPixResponse>>, IValida
{
    public decimal Valor { get; set; }

    public DateTime Data { get; set; }

    public string ChavePixOrigem { get; set; } = default!;
    public string ChavePixDestino { get; set; } = default!;
}
