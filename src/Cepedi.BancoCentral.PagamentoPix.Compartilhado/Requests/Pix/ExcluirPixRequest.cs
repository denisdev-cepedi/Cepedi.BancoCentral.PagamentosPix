using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;

public class ExcluirPixRequest : IRequest<Result<ExcluirPixResponse>>
{
    public int idPix { get; set; }
}
