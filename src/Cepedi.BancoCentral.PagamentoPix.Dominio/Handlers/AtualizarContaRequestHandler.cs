﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
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
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<AtualizarContaRequestHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public AtualizarContaRequestHandler(IContaRepository contaRepository,
            ILogger<AtualizarContaRequestHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _contaRepository = contaRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
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

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(new AtualizarContaResponse(contaEntity.Conta, contaEntity.Agencia));


        }
    }
}
