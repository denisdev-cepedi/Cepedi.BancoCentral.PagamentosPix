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
    public class AtualizarPessoaRequestHandler :
            IRequestHandler<AtualizarPessoaRequest, Result<AtualizarPessoaResponse>>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogger<AtualizarPessoaRequestHandler> _logger;
        public AtualizarPessoaRequestHandler(IPessoaRepository pessoaRepository, ILogger<AtualizarPessoaRequestHandler> logger){
            _pessoaRepository = pessoaRepository;
            _logger = logger;
        }
        public async Task<Result<AtualizarPessoaResponse>> Handle(AtualizarPessoaRequest request, CancellationToken cancellationToken)
        {
           
                var pessoaEntity = await _pessoaRepository.ObtemPessoaPorIdAsync(request.IdPessoa);
                if (pessoaEntity == null)
                {
                    return Result.Error<AtualizarPessoaResponse>(
                        new Compartilhado.Excecoes.SemResultadosExcecao());
                }

                pessoaEntity.Atualizar(request.Nome, request.Cpf, request.IdConta);

                await _pessoaRepository.AtualizarPessoaAsync(pessoaEntity);

                return Result.Success(new AtualizarPessoaResponse(pessoaEntity.Nome, pessoaEntity.Cpf, pessoaEntity.IdConta));
                
           
        }
    }
}