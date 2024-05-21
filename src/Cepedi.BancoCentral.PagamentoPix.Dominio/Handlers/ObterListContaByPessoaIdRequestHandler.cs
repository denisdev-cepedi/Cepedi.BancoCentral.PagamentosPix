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
    public class ObterListContaByPessoaIdRequestHandler :
        IRequestHandler<ObterListContaByPessoaIdRequest, Result<ObterListContaByPessoaIdResponse>>
    {
        private readonly ILogger<ObterListContaByPessoaIdRequestHandler> _logger;
        private readonly IContaRepository _contaRepositorio;

        public ObterListContaByPessoaIdRequestHandler(
            ILogger<ObterListContaByPessoaIdRequestHandler> logger,
            IContaRepository contaRepositorio)
            {
                _logger = logger;
                _contaRepositorio = contaRepositorio;
            }

        public async Task<Result<ObterListContaByPessoaIdResponse>> Handle(ObterListContaByPessoaIdRequest request, CancellationToken cancellationToken)
        {
            var contas = await _contaRepositorio.ObtemContasAsync(request.IdPessoa);

            var response = new ObterListContaByPessoaIdResponse()
            {
                Contas = contas.Select(c => new ObterContaResponse()
                {
                    IdConta = c.IdConta,
                    IdPessoa = c.IdPessoa,
                    Conta = c.Conta,
                    Agencia = c.Agencia
                }).ToList()
            };
            return Result.Success(response);

        }
    }
}