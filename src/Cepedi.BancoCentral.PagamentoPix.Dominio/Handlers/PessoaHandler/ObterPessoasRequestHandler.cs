using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers
{
    public class ObterPessoasRequestHandler : IRequestHandler<ObterListPessoasRequest, Result<List<ObterPessoaResponse>>>
    {
        private readonly ILogger<ObterPessoasRequestHandler> _logger;
        private readonly IPessoaRepository _pessoaRepositorio;

        public ObterPessoasRequestHandler(ILogger<ObterPessoasRequestHandler> logger, IPessoaRepository pessoaRepositorio)
        {
            _logger = logger;
            _pessoaRepositorio = pessoaRepositorio;
        }

        public async Task<Result<List<ObterPessoaResponse>>> Handle(ObterListPessoasRequest request, CancellationToken cancellationToken)
        {
            var pessoas = await _pessoaRepositorio.ObtemPessoasAsync();

            if (pessoas == null)
            {
                return Result.Error<List<ObterPessoaResponse>>(
                    new Compartilhado.Excecoes.ExcecaoAplicacao(
                        (PagamentosPix.PessoaInexistente))
                    );
            }

            return Result.Success(new List<ObterPessoaResponse>(pessoas.Select(x => new ObterPessoaResponse(x.IdPessoa, x.Nome, x.Cpf))));
        }

    }
}