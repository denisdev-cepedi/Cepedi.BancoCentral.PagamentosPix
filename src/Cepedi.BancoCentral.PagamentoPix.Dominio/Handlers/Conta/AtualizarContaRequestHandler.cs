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
    public class AtualizarContaRequestHandler :
            IRequestHandler<AtualizarContaRequest, Result<AtualizarContaResponse>>
    {
        private readonly IContaRepository _contaRepository;
        private readonly ILogger<AtualizarContaRequestHandler> _logger;
        public AtualizarContaRequestHandler(IContaRepository contaRepository, ILogger<AtualizarContaRequestHandler> logger){
            _contaRepository = contaRepository;
            _logger = logger;
        }
        public async Task<Result<AtualizarContaResponse>> Handle(AtualizarContaRequest request, CancellationToken cancellationToken)
        {
           
                var contaEntity = await _contaRepository.ObtemContaPorIdAsync(request.IdConta);
                if (contaEntity == null)
                {
                    return Result.Error<AtualizarContaResponse>(
                        new Compartilhado.Excecoes.SemResultadosExcecao());
                }

                contaEntity.Atualizar(request.Conta, request.Agencia);

                await _contaRepository.AtualizarContaAsync(contaEntity);

                return Result.Success(new AtualizarContaResponse(contaEntity.Conta, contaEntity.Agencia));
                
           
        }
    }
}