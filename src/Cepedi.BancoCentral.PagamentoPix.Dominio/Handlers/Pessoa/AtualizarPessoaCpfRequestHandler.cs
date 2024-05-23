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
    public class AtualizarPessoaCpfRequestHandler :
            IRequestHandler<AtualizarPessoaCpfRequest, Result<AtualizarPessoaResponse>>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPixRepository _pixRepository;
        private readonly ILogger<AtualizarPessoaCpfRequestHandler> _logger;
        public AtualizarPessoaCpfRequestHandler(IPessoaRepository pessoaRepository, 
            ILogger<AtualizarPessoaCpfRequestHandler> logger,
            IPixRepository pixRepository){
            _pessoaRepository = pessoaRepository;
            _logger = logger;
            _pixRepository = pixRepository;
        }
        public async Task<Result<AtualizarPessoaResponse>> Handle(AtualizarPessoaCpfRequest request, CancellationToken cancellationToken)
        {
           
                var pessoaEntity = await _pessoaRepository.ObtemPessoaPorCpfAsync(request.Cpf);
                if (pessoaEntity == null)
                {
                    return Result.Error<AtualizarPessoaResponse>(
                        new Compartilhado.Excecoes.ExcecaoAplicacao(
                            (PagamentosPix.PessoaInexistente)
                        ));
                }

                if (pessoaEntity.Cpf != request.NovoCpf)
                {
                    var PessoaEntity2 = await _pessoaRepository.ObtemPessoaPorCpfAsync(request.NovoCpf);
                    
                    if(PessoaEntity2 != null)
                    {
                        return Result.Error<AtualizarPessoaResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                            (PagamentosPix.PessoaJaCadastrada)
                        ));
                    }
                    var PixEntity = await _pixRepository.ObterChavePixAsync(request.Cpf);

                    if(PixEntity != null)
                    {
                        return Result.Error<AtualizarPessoaResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                            (PagamentosPix.CpfComPixJaCadastrado)
                        ));
                    }
                }
        
                pessoaEntity.AtualizarCpf(request.NovoCpf);

                await _pessoaRepository.AtualizarPessoaAsync(pessoaEntity);

                return Result.Success(new AtualizarPessoaResponse(pessoaEntity.Nome, pessoaEntity.Cpf));
                
           
        }
    }
}