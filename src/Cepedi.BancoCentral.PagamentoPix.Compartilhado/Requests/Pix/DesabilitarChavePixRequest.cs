using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;

public class DesabilitarChavePixRequest: IRequest<Result<DesabilitarChavePixResponse>>, IValida{
    public required string TipoPix { get; set; }
    public required string ChavePix { get; set; }

}