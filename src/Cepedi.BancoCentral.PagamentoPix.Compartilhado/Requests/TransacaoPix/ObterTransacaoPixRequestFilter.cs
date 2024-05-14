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
    public ObterTransacaoPixRequestFilter(DateTime dataInicial, DateTime dataFinal) {
        // , string chaveOrigem, string chaveDestino
        DataInicial = dataInicial;
        DataFinal = dataFinal;
        // ChaveOrigem = chaveOrigem;
        // ChaveDestino = chaveDestino;
    }
    public DateTime DataInicial { get; set; }
    public DateTime DataFinal { get; set; }
    // public string ChaveOrigem { get; set; }
    // public string ChaveDestino { get; set; } 

}
