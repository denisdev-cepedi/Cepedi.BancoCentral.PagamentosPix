using Cepedi.BancoCentral.PagamentoPix.Compartilhado;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

public class AtualizarContaResquest: IRequest<Result<AtualizarContaResponse>>, IValida
{
    public int IdConta { get; set; }
    public int IdPessoa { get; set; }
    public string Numero { get; set; } = default!; //numero da instituição pertencedora
    public required string Agencia { get; set; }
    public required string Conta { get; set; } = default!;
    
}
