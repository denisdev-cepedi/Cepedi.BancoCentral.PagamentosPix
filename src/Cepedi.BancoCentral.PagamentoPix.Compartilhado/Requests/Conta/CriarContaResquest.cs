using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests
{
    public class CriarContaRequest : IRequest<Result<CriarContaResponse>>, IValida
    {
        public int IdPessoa { get; set; }
        public string Numero { get; set; } = default!; //numero da instituição pertencedora
        public required string Agencia { get; set; }
        public required string Conta { get; set; } = default!;

        public required string Cpf { get; set; } = default!;

    }
}
