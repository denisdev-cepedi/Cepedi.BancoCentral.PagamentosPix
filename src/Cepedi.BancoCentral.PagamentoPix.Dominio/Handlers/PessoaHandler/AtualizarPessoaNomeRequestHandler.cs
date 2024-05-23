using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers
{
    public class AtualizarPessoaNomeRequestHandler :
            IRequestHandler<AtualizarPessoaNomeRequest, Result<AtualizarPessoaResponse>>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogger<AtualizarPessoaNomeRequestHandler> _logger;
        public AtualizarPessoaNomeRequestHandler(IPessoaRepository pessoaRepository, ILogger<AtualizarPessoaNomeRequestHandler> logger){
            _pessoaRepository = pessoaRepository;
            _logger = logger;
        }
        public async Task<Result<AtualizarPessoaResponse>> Handle(AtualizarPessoaNomeRequest request, CancellationToken cancellationToken)
        {
           
                var pessoaEntity = await _pessoaRepository.ObtemPessoaPorCpfAsync(request.Cpf);
                if (pessoaEntity == null)
                {
                    return Result.Error<AtualizarPessoaResponse>(
                        new Compartilhado.Excecoes.ExcecaoAplicacao(
                            (PagamentosPix.PessoaInexistente)
                        ));
                }

                pessoaEntity.AtualizarNome(request.Nome);

                await _pessoaRepository.AtualizarPessoaAsync(pessoaEntity);

                return Result.Success(new AtualizarPessoaResponse(pessoaEntity.Nome, pessoaEntity.Cpf));
        }
    }
}