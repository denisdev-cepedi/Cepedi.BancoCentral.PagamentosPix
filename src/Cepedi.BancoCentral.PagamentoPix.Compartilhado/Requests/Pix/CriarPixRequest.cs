using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;

public class CriarPixRequest : IRequest<Result<CriarPixResponse>>, IValida
{

    public required string CodigoInstituicao { get; set; }
    public required string Agencia { get; set; }
    public required string Conta { get; set; }
    public required string TipoPix { get; set; }
    public required string ChavePix { get; set; }

}