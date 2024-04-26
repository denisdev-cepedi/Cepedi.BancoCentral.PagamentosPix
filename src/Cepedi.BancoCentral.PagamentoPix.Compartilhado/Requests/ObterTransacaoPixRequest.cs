using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
public class ObterTransacaoPixRequest : IRequest<Result<ObterTransacaoPixResponse>>
{
    public ObterTransacaoPixRequest(int idTransacaoPix) => IdTransacaoPix = idTransacaoPix;
    public int IdTransacaoPix { get; set; }
}
