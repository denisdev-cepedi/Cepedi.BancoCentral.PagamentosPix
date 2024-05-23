using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers
{
    public class CriarContaRequestHandler : IRequestHandler<CriarContaRequest, Result<CriarContaResponse>>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogger<CriarContaRequestHandler> _logger;


        public CriarContaRequestHandler(IContaRepository contaRepository, ILogger<CriarContaRequestHandler> logger, IPessoaRepository pessoaRepository)
        {
            _contaRepository = contaRepository;
            _logger = logger;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Result<CriarContaResponse>> Handle(CriarContaRequest request, CancellationToken cancellationToken)
        {
            var contaEntity = await _contaRepository.ObterContaBankAsync(request.Numero, request.Agencia, request.Conta);
            if (contaEntity != null )
            {
                return Result.Error<CriarContaResponse>(
                    new Compartilhado.Excecoes.ExcecaoAplicacao(
                        PagamentosPix.ContaJaExistente
                    ));
            }

           var pessoa = await _pessoaRepository.ObtemPessoaPorCpfAsync(request.Cpf);

            if (pessoa == null){
                return Result.Error<CriarContaResponse>(
                    new Compartilhado.Excecoes.ExcecaoAplicacao(
                        PagamentosPix.PessoaInexistente
                    ));
            }

        
            var conta = new ContaEntity
            {
                IdPessoa = request.IdPessoa,
                Agencia = request.Agencia,
                Conta = request.Conta,
                Numero = request.Numero
            };

            await _contaRepository.CriarContaAsync(conta);

            return Result.Success(new CriarContaResponse(conta.IdConta, request.Agencia, request.Conta,  pessoa.Nome, request.Cpf));
        }

    }
}
