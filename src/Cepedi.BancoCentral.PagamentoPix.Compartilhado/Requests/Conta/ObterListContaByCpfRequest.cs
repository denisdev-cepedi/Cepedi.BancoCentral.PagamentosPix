using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests
{
 public class ObterListContaByCpfRequest : IRequest<Result<ObterListContaByCpfResponse>>
 {
    public int Cpf { get; set; }

    public ObterListContaByCpfRequest(int cpf)
    {
        Cpf = cpf;
    }
}
}