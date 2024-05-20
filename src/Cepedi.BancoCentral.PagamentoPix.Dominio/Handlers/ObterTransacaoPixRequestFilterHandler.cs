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
    public class ObterTransacaoPixRequestFilterHandler: IRequestHandler<ObterTransacaoPixRequestFilter, Result<ObterListTransacoesPixResponse>>
    {
        private readonly ILogger<ObterTransacaoPixRequestFilterHandler> _logger;
        private readonly ITransacaoPixRepository _transacaoPixRepository;
        public ObterTransacaoPixRequestFilterHandler(ILogger<ObterTransacaoPixRequestFilterHandler> logger, ITransacaoPixRepository transacaoPixRepository)
        {
            _logger = logger;
            _transacaoPixRepository = transacaoPixRepository;
        }

        public async Task<Result<ObterListTransacoesPixResponse>>  Handle(ObterTransacaoPixRequestFilter request, CancellationToken cancellationToken)
        {
            var transacoesPix = await _transacaoPixRepository.ObterTransacoesPixFilterAsync(request);
            if (transacoesPix == null)
            {
                return Result.Error<ObterListTransacoesPixResponse>(
                    new Compartilhado.Excecoes.SemResultadosExcecao()
                );
            }
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