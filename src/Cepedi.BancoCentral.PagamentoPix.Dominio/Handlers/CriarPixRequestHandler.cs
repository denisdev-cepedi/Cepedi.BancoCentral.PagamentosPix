using System.Reflection;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers;

public class CriarPixRequestHandler : IRequestHandler<CriarPixRequest, Result<CriarPixResponse>>
{
    private readonly ILogger<CriarPixRequestHandler> _logger;
    private readonly IPixRepository _pixRepository;
    // private readonly IContaRepository _contaRepository;

    public CriarPixRequestHandler(IPixRepository pixRepository, ILogger<CriarPixRequestHandler> logger){
        _pixRepository = pixRepository;
        _logger = logger;
    }

    public async Task<Result<CriarPixResponse>> Handle(CriarPixRequest request, CancellationToken cancellationToken)
    {
        //devo verificar se a chave pix ja existe, e a conta deve existir e a pessoa deve existir retonando uma excecão
        //caso esses dados sejam invalidos, retornar uma excecão???
        
      
            var pixEntity = await _pixRepository.ObterChavePixAsync(request.ChavePix);
            if(pixEntity != null){
                _logger.LogError("Chave Pix ja existe");
                return Result.Error<CriarPixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                    (PagamentosPix.ChavePixJaCadastrada))
                );
            }
            var pix = new PixEntity()
            {
                IdPix = request.idPix,
                IdTipoPix = request.IdTipoPix,
                ChavePix = request.ChavePix,
                IdConta = request.IdConta,
                IdPessoa = request.IdPessoa,
                DataCriacao = DateTime.Now,
                Status = true
            };

            await _pixRepository.CriarPixAsync(pix);
            return Result.Success(new CriarPixResponse(pix.IdPix, pix.ChavePix));

       
    }
}