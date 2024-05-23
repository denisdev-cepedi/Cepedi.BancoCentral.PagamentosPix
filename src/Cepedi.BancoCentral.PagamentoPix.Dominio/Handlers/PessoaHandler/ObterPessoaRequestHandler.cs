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
    public class ObterPessoaRequestHandler :
        IRequestHandler<ObterPessoaRequest, Result<ObterPessoaResponse>>
    {
        private readonly ILogger<ObterPessoaRequestHandler> _logger;
        private readonly IPessoaRepository _pessoaRepositorio;

        public ObterPessoaRequestHandler(
            ILogger<ObterPessoaRequestHandler> logger,
            IPessoaRepository pessoaRepositorio)
            {
                _logger = logger;
                _pessoaRepositorio = pessoaRepositorio;
            }
        public async Task<Result<ObterPessoaResponse>> Handle(ObterPessoaRequest request, CancellationToken cancellationToken)
        {
            var pessoa = await _pessoaRepositorio.ObtemPessoaPorCpfAsync(request.Cpf);
            
            if (pessoa == null)
            {
                return Result.Error<ObterPessoaResponse>(
                    new Compartilhado.Excecoes.ExcecaoAplicacao(
                        (PagamentosPix.PessoaInexistente)
                    ));
            }

            return Result.Success(new ObterPessoaResponse(pessoa.IdPessoa, pessoa.Nome, pessoa.Cpf));
        }
    }
}