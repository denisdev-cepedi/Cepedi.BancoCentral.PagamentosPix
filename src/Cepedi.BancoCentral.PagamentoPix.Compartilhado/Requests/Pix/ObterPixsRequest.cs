using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;

public class ObterPixsRequest: IRequest<Result<List<ObterPixsResponse>>>
{}