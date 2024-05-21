using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;

using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers
{
    public class ObterListContaByCpfRequestHandler : IRequestHandler<ObterListContaByCpfRequest, Result<ObterListContaByCpfResponse>>
    {
        private readonly IContaRepository _contaRepository;

        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogger<ObterListContaByCpfRequestHandler> _logger;


        public ObterListContaByCpfRequestHandler(IContaRepository contaRepository, ILogger<ObterListContaByCpfRequestHandler> logger, IPessoaRepository pessoaRepository)
        {
            _contaRepository = contaRepository;
            _logger = logger;
            _pessoaRepository = pessoaRepository;
            
        }

        

        public async Task<Result<ObterListContaByCpfResponse>> Handle(ObterListContaByCpfRequest request, CancellationToken cancellationToken)
{
    var pessoa = await _pessoaRepository.ObtemPessoaPorCpfAsync(request.Cpf);


    if ( pessoa == null)
    {
        _logger.LogError("CPF não encontrado");
        return Result.Error<CriarContaResponse>(
            new Compartilhado.Excecoes.ExcecaoAplicacao(
                        (PagamentosPix.PessoaInexistente)
                    ));
    }

            var response = new ObterListContaByCpfResponse()
            {
                Contas = pessoa.Select(c => new ObterPessoaResponse()
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