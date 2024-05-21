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
    public class ObterListContaByCpfRequestHandler :
        IRequestHandler<ObterListContaByCpfRequest, Result<ObterListContaByCpfResponse>>
    {
        private readonly ILogger<ObterListContaByCpfRequestHandler> _logger;
        private readonly IContaRepository _contaRepositorio;

        public ObterListContaByCpfRequestHandler(
            ILogger<ObterListContaByCpfRequestHandler> logger,
            IContaRepository contaRepositorio)
            {
                _logger = logger;
                _contaRepositorio = contaRepositorio;
            }

        public async Task<Result<ObterListContaByCpfResponse>> Handle(ObterListContaByCpfRequest request, CancellationToken cancellationToken)
        {
            var contas = await _contaRepositorio.ObtemContasAsync(request.Cpf);

            var response = new ObterListContaByCpfResponse()
            {
                Contas = contas.Select(c => new ObterContaResponse()
                {
                    IdConta = c.IdConta,
                    IdPessoa = c.IdPessoa,
                    Numero = c.Numero,
                    Conta = c.Conta,
                    Agencia = c.Agencia
                }).ToList()
            };
            return Result.Success(response);

        }
    }
}