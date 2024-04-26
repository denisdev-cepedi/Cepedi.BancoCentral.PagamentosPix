using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests
{
    public class ObterContaRequest: IRequest<Result<ObterContaResponse>>
    {
        public int IdConta { get; set; }
        public ObterContaRequest(int IdConta) => this.IdConta = IdConta;
    }
}