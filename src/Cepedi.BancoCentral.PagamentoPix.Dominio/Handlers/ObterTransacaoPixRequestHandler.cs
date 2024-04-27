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
    public class ObterTransacaoPixRequestHandler : IRequestHandler<ObterTransacaoPixRequest, Result<ObterTransacaoPixResponse>>
    {

        private readonly ILogger<ObterTransacaoPixRequest> _logger;
        private readonly ITransacaoPixRepository _transacaoPixRepository;

        public ObterTransacaoPixRequestHandler(ITransacaoPixRepository transacaoPixRepository, ILogger<ObterTransacaoPixRequest> logger)
        {
            _transacaoPixRepository = transacaoPixRepository;
            _logger = logger;
        }
        public async Task<Result<ObterTransacaoPixResponse>> Handle(ObterTransacaoPixRequest request, CancellationToken cancellationToken)
        {
            var transacaoPix = await _transacaoPixRepository.ObterTransacaoPixAsync(request.IdTransacaoPix);
            
            if (transacaoPix == null)
            {
                return Result.Error<ObterTransacaoPixResponse>(
                    new Compartilhado.Excecoes.SemResultadosExcecao());
            }

            var response = new ObterTransacaoPixResponse
            (
                transacaoPix.IdTransacaoPix,
                transacaoPix.Valor,
                transacaoPix.Data,
                transacaoPix.ChaveDeSeguranca,
                transacaoPix.IdPixOrigem,
                transacaoPix.IdPixDestino

            );
            
            return Result.Success(response);
        }
    }
}