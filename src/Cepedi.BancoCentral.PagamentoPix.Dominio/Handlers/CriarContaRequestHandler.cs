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
    public class CriarContaRequestHandler :
            IRequestHandler<CriarContaRequest, Result<CriarContaResponse>>
    {
        private readonly IContaRepository _contaRepository;
        private readonly ILogger<CriarContaRequestHandler> _logger;

        public CriarContaRequestHandler(IContaRepository contaRepository, ILogger<CriarContaRequestHandler> logger)
        {
            _contaRepository = contaRepository;
            _logger = logger;
        }

        public async Task<Result<CriarContaResponse>> Handle(CriarContaRequest request, CancellationToken cancellationToken)
        {


            var conta = new ContaEntity
            {
                IdPessoa = request.IdPessoa,
                Numero = request.Numero,
                Agencia = request.Agencia,
                Conta = request.Conta
            };

           
            await _contaRepository.CriarContaAsync(conta);

            
            return Result.Success(new CriarContaResponse(conta.IdConta, conta.IdPessoa));
        }
    }

    
}
