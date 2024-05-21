using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class CriarPessoaRequestHandler: 
            IRequestHandler<CriarPessoaRequest, Result<CriarPessoaResponse>>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogger<CriarPessoaRequestHandler> _logger;

        public CriarPessoaRequestHandler(IPessoaRepository pessoaRepository, ILogger<CriarPessoaRequestHandler> logger){
            _pessoaRepository = pessoaRepository;
            _logger = logger;
        }
         
        public async Task<Result<CriarPessoaResponse>> Handle(CriarPessoaRequest request, CancellationToken cancellationToken)
        {
            var PessoaEntity = await _pessoaRepository.ObtemPessoaPorCpfAsync(request.Cpf);
            if(PessoaEntity != null)
            {
                return Result.Error<CriarPessoaResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                    (PagamentosPix.PessoaJaCadastrada)
                ));
            }

                var pessoa = new PessoaEntity{
                        Nome = request.Nome,
                        Cpf = request.Cpf
                };
                await _pessoaRepository.CriarPessoaAsync(pessoa);
                return Result.Success(new CriarPessoaResponse(pessoa.IdPessoa, pessoa.Nome));
          
        }
    }
}