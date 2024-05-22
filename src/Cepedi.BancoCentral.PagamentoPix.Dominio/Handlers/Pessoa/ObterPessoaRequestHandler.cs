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
        private readonly ICache<PessoaEntity> _cache;

        public ObterPessoaRequestHandler(
            ILogger<ObterPessoaRequestHandler> logger,
            IPessoaRepository pessoaRepositorio,
            ICache<PessoaEntity> cache)
            {
                _logger = logger;
                _pessoaRepositorio = pessoaRepositorio;
                _cache = cache;
            }
        public async Task<Result<ObterPessoaResponse>> Handle(ObterPessoaRequest request, CancellationToken cancellationToken)
        {
            var cacheKey = $"Pessoa_{request.Cpf}";
            var pessoaCache = await _cache.ObterAsync(cacheKey);

            if (pessoaCache == null)
            {
                var pessoa = await _pessoaRepositorio.ObtemPessoaPorCpfAsync(request.Cpf);

                if (pessoa == null)
                {
                    return Result.Error<ObterPessoaResponse>(
                        new Compartilhado.Excecoes.ExcecaoAplicacao(
                            (PagamentosPix.PessoaInexistente)
                        ));
                }
                await _cache.SalvarAsync(cacheKey, pessoa);
            }
            return Result.Success(new ObterPessoaResponse(pessoa.IdPessoa, pessoa.Nome, pessoa.Cpf));
        }
    }
}