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
    public class ObterPessoasRequestHandler : IRequestHandler<ObterListPessoasRequest, Result<ObterListPessoasResponse>>
    {
        private readonly ILogger<ObterPessoasRequestHandler> _logger;
        private readonly IPessoaRepository _pessoaRepositorio;

        public ObterPessoasRequestHandler(ILogger<ObterPessoasRequestHandler> logger, IPessoaRepository pessoaRepositorio) 
        {
            _logger = logger;
            _pessoaRepositorio = pessoaRepositorio;
        }

        public async Task<Result<ObterListPessoasResponse>> Handle(ObterListPessoasRequest request, CancellationToken cancellationToken)
        {
            var pessoas = await _pessoaRepositorio.ObtemPessoasAsync();
            
            var response = new ObterListPessoasResponse()
            {
                Pessoas = pessoas.Select(p => new ObterPessoaResponse()
                {
                    IdPessoa = p.IdPessoa,
                    Nome = p.Nome
                }).ToList()
            };

            return Result.Success(response).Value;
        }
    }
}