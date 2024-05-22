using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers
{
    public class ObterContaBankRequestHandler : IRequestHandler<ObterContaBankRequest, Result<ObterContaBankResponse>>
    {
        private readonly IContaRepository _contaRepository;
        private readonly ILogger<ObterContaBankRequestHandler> _logger;

        public ObterContaBankRequestHandler(IContaRepository contaRepository, ILogger<ObterContaBankRequestHandler> logger)
        {
            _contaRepository = contaRepository;
            _logger = logger;
        }

        public async Task<Result<ObterContaBankResponse>> Handle(ObterContaBankRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.ObterContaBankAsync(request.Agencia, request.Conta, request.Numero);

            if (conta == null)
            {
                _logger.LogError("Conta não encontrada");
                return Result.Error<ObterContaBankResponse>(new ExcecaoAplicacao(PagamentosPix.ContaInexistente));
            }

            var response = new ObterContaBankResponse
            {
                
                Numero = conta.Numero,
                Agencia = conta.Agencia,
                Conta = conta.Conta
            };

            return Result.Success(response);
        }
    }
}