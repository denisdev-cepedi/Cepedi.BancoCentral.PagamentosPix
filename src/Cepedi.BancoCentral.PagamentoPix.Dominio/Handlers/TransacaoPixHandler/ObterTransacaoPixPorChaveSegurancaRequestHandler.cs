using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers
{
    public class ObterTransacaoPixPorChaveSegurancaRequestHandler : IRequestHandler<ObterTransacoesPorChaveDeSegurancaRequest, Result<ObterTransacaoPixResponse>>
    {
        private readonly ILogger<ObterTransacoesPixPorChavePixRequestHandler> _logger;
        private readonly ITransacaoPixRepository _transacaoPixRepository;

        public ObterTransacaoPixPorChaveSegurancaRequestHandler(ILogger<ObterTransacoesPixPorChavePixRequestHandler> logger, ITransacaoPixRepository transacaoPixRepository)
        {
            _logger = logger;
            _transacaoPixRepository = transacaoPixRepository;
        }

        public async Task<Result<ObterTransacaoPixResponse>> Handle(ObterTransacoesPorChaveDeSegurancaRequest request, CancellationToken cancellationToken)
        {
            var transacaoPix = await _transacaoPixRepository.ObterIdPorChaveSegurancaAsync(request.ChaveSeguranca);

            if (transacaoPix == null)
            {
                _logger.LogError("Sem resultados");

                return Result.Error<ObterTransacaoPixResponse>(
                        new Compartilhado.Excecoes.SemResultadosExcecao());
            }

            var chavePixOrigem = await _transacaoPixRepository.ObterChavePixPorIdAsync(transacaoPix.IdPixOrigem);
            var chavePixDestino = await _transacaoPixRepository.ObterChavePixPorIdAsync(transacaoPix.IdPixDestino);

            var response = new ObterTransacaoPixResponse
            (
                transacaoPix.IdTransacaoPix,
                transacaoPix.Valor,
                transacaoPix.Data,
                transacaoPix.ChaveDeSeguranca,
                chavePixOrigem,
                chavePixDestino
            );

            return Result.Success(response);
        }
    }
}
