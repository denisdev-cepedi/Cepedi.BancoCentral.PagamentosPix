using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests
{
    public class ObterPessoaRequest : IRequest<Result<ObterPessoaResponse>>
    {
        public ObterPessoaRequest(int idPessoa) => IdPessoa = idPessoa;
        public int IdPessoa { get; set; }
    }
}