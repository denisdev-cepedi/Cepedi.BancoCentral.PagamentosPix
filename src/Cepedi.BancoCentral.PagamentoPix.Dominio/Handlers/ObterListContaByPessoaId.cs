using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class ObterListContaByPessoaIdRequestHandler : IRequestHandler<ObterListContaByPessoaIdRequest, Result<ObterListContaByPessoaIdResponse>>
    {

        private readonly ILogger<ObterListContaByPessoaIdRequest> _logger;
        private readonly IContaRepository _contaRepository;

        public ObterListContaByPessoaIdRequestHandler(IContaRepository contaRepository, ILogger<ObterListContaByPessoaIdRequest> logger)
        {
            _contaRepository = contaRepository;
            _logger = logger;
        }
        public async Task<Result<ObterListContaByPessoaIdResponse>> Handle(ObterListContaByPessoaIdRequest request, CancellationToken cancellationToken)
        {
            var contas = await _contaRepository.ObterListContaByPessoaIdAsync(request.IdPessoa);

            if (contas == null || !contas.Any())
            {
                return Result.Error<ObterListContaByPessoaIdResponse>(
                    new Compartilhado.Excecoes.SemResultadosExcecao());
            }

            var response = new ObterListContaByPessoaIdResponse
            {
                Contas = contas.Select(conta => new ObterContaResponse
                {
                    IdConta = conta.IdConta,
                    IdPessoa = conta.IdPessoa,
                    Agencia = conta.Agencia,
                    Conta = conta.Conta
                }).ToList()
            };

            return Result.Success(response);
        }
    }
}