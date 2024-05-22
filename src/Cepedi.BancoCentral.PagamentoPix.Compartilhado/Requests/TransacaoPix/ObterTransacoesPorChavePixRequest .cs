using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

public class ObterTransacoesPorChavePixRequest : IRequest<Result<ObterListTransacoesPixResponse>>
{
    public string ChavePix { get; }

    public ObterTransacoesPorChavePixRequest(string chavePix)
    {
        ChavePix = chavePix;
    }
}
