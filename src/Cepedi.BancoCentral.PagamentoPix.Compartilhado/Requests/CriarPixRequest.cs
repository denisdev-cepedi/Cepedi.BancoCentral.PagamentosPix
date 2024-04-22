using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
public class CriarPixRequest : IRequest<Result<CriarPixResponse>>
{
    public int idPix { get; set; }
    public int IdConta { get; set; }
    public int IdPessoa { get; set; }
    public string ChavePix { get; set; } = default!;
    public int IdTipoPix { get; set; }
}