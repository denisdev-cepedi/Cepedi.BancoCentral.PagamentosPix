using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests
{
    public record CriarPessoaRequest: IRequest<Result<CriarPessoaResponse>>
    {
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public string IdConta { get; set; } = default!;
    }
    
}