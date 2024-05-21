using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests
{
    public class AtualizarPessoaCpfRequest : IRequest<Result<AtualizarPessoaResponse>>, IValida
    { 
        public required string Cpf { get; set; }
        public string NovoCpf { get; set; }
    }
    
}