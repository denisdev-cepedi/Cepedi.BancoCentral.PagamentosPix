using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

public class ObterTransacoesPorChaveDeSegurancaRequest : IRequest<Result<ObterTransacaoPixResponse>>
{
    public string ChaveSeguranca { get; }

    public ObterTransacoesPorChaveDeSegurancaRequest(string chaveSeguranca)
    {
        ChaveSeguranca = chaveSeguranca;
    }
}
