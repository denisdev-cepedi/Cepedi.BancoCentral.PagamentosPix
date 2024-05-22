using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
    public class ObterListContaByCpfRequestHandler : IRequestHandler<ObterListContaByCpfRequest, 
    Result<ObterListContaByCpfResponse>>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogger<ObterListContaByCpfRequestHandler> _logger;

        public ObterListContaByCpfRequestHandler(IContaRepository contaRepository, 
        ILogger<ObterListContaByCpfRequestHandler> logger, IPessoaRepository pessoaRepository)
        {
            _contaRepository = contaRepository;
            _logger = logger;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Result<ObterListContaByCpfResponse>> 
        Handle(ObterListContaByCpfRequest request, CancellationToken cancellationToken)
        {
            var pessoa = await _pessoaRepository.ObtemPessoaPorCpfAsync(request.Cpf);

           if (pessoa == null)
            {
                _logger.LogError("CPF não encontrado");
                return Result.Error<ObterListContaByCpfResponse>(
                    new ExcecaoAplicacao(PagamentosPix.PessoaInexistente));
            }

            var contas = await _contaRepository.ObtemContasAsync(pessoa.IdPessoa);

            var response = new ObterListContaByCpfResponse
            {
                Contas = contas.Select(conta => new ObterContaResponse
                {
                    IdConta = conta.IdConta,
                    IdPessoa = conta.IdPessoa,
                    Numero = conta.Numero,
                    Conta = conta.Conta,
                    Agencia = conta.Agencia
                }).ToList()
            };

            return Result.Success(response);
        }
    }
}
