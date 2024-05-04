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
    public class ObterTransacoesPixRequestHandler : IRequestHandler<ObterListTransacoesPixRequest, Result<ObterListTransacoesPixResponse>>
    {
        private readonly ILogger<ObterTransacoesPixRequestHandler> _logger;
        private readonly ITransacaoPixRepository _transacaoPixRepository;

        public ObterTransacoesPixRequestHandler(ILogger<ObterTransacoesPixRequestHandler> logger, ITransacaoPixRepository transacaoPixRepository)
        {
            _logger = logger;
            _transacaoPixRepository = transacaoPixRepository;
        }

        public async Task<Result<ObterListTransacoesPixResponse>> Handle(ObterListTransacoesPixRequest request, CancellationToken cancellationToken)
        {
            var transacoesPix = await _transacaoPixRepository.ObterTransacoesPixAsync();

            var response = new ObterListTransacoesPixResponse()
            {
                TransacoesPix = transacoesPix.Select(p => new ObterTransacaoPixResponse
                (
                    p.IdTransacaoPix,
                    p.Valor,
                    p.Data,
                    p.ChaveDeSeguranca,
                    p.IdPixOrigem,
                    p.IdPixDestino
                )).ToList()
            };

            return Result.Success(response).Value;
        }
    }
}