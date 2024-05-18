using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
public class ObterTransacaoPixRequestFilter : IRequest<Result<ObterListTransacoesPixResponse>>
{
    public DateTime DataInicial { get; set; }
    public DateTime DataFinal { get; set; }
    // public string ChaveOrigem { get; set; }
    // public string ChaveDestino { get; set; } 

}
