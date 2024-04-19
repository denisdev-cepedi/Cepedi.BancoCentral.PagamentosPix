using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests
{
    public class AtualizarPessoaRequest : IRequest<Result<AtualizarPessoaResponse>>
    {
        public int IdPessoa { get; set; }
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public int IdConta { get; set; }
    }
}