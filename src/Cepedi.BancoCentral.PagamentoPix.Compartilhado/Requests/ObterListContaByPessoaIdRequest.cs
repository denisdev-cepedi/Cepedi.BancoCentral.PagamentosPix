using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests
{
    public class ObterListContaByPessoaIdRequest: IRequest<Result<ObterListContaByPessoaIdResponse>>
    {
        public int IdPessoa { get; set; }

        public ObterListContaByPessoaIdRequest(int idPessoa) => IdPessoa = idPessoa;

    }
}