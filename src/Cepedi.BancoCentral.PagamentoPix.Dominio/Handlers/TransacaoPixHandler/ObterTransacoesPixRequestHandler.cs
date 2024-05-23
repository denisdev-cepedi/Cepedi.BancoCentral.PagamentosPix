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

            if (transacoesPix == null){
                _logger.LogError("Sem resultados");
                return Result.Error<ObterListTransacoesPixResponse>(
                    new Compartilhado.Excecoes.SemResultadosExcecao());
            }
            
            var response = new ObterListTransacoesPixResponse()
            {
                TransacoesPix = new List<ObterTransacaoPixResponse>()
            };

            foreach (var transacao in transacoesPix)
            {

                var transacaoResponse = new ObterTransacaoPixResponse
                (
                    transacao.IdTransacaoPix,
                    transacao.Valor,
                    transacao.Data,
                    transacao.ChaveDeSeguranca,
                    transacao.PixOrigem.ChavePix,
                    transacao.PixDestino.ChavePix
                );
                
                response.TransacoesPix.Add(transacaoResponse);
            }

            return Result.Success(response);
        }
    }
}
