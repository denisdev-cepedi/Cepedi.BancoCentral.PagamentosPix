using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

// Add this line

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests
{
    public class ObterListContaByCpfRequest : IRequest<Result<ObterListContaByCpfResponse>>
    {
        public string Cpf { get; set; }

        public ObterListContaByCpfRequest(string cpf)
        {
            Cpf = cpf;
        }
    }
}