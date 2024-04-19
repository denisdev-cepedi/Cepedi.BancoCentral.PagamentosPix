using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers;
public class CriarTransacaoPixRequestHandler : IRequestHandler<CriarTransacaoPixRequest, Result<CriarTransacaoPixResponse>>
{

    private readonly ILogger<CriarTransacaoPixRequestHandler> _logger;
    private readonly ITransacaoPixRepository _transacaoPixRepository;

    public CriarTransacaoPixRequestHandler(ITransacaoPixRepository transacaoPixRepository, ILogger<CriarTransacaoPixRequestHandler> logger)
    {
        _transacaoPixRepository = transacaoPixRepository;
        _logger = logger;
    }
    public async Task<Result<CriarTransacaoPixResponse>> Handle(CriarTransacaoPixRequest request, CancellationToken cancellationToken)
    {

        var transacao = new TransacaoPixEntity()
        {
            Valor = request.Valor,
            Data = request.Data,
            ChavePix = request.ChavePix,
            ChaveDeSeguranca = request.ChaveDeSeguranca,
            IdPixOrigem = request.IdPixOrigem,
            IdPixDestino = request.IdPixDestino
        };

        await _transacaoPixRepository.CriarTransacaoPixAsync(transacao);

        return Result.Success(new CriarTransacaoPixResponse(transacao.Id, transacao.Valor));
    }
}
