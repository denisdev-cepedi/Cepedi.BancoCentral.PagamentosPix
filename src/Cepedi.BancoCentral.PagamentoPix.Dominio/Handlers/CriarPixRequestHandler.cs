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
    private readonly IContaRepository _contaRepository;

    public CriarPixRequestHandler(IPixRepository pixRepository, IContaRepository contaRepository, ILogger<CriarPixRequestHandler> logger)
    {
        _pixRepository = pixRepository;
        _contaRepository = contaRepository;
        _logger = logger;
    }

    public async Task<Result<CriarPixResponse>> Handle(CriarPixRequest request, CancellationToken cancellationToken)
    {
        //teorizando que eu pode ter um pix com a mesma chave e difente conta se 
        //estiver desabilitado
        var pixEntity = await _pixRepository.ObterChavePixAsync(request.ChavePix);
        if (pixEntity != null && pixEntity.Status == true)
        {
            _logger.LogError("Chave Pix ja existe");
            return Result.Error<CriarPixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (PagamentosPix.ChavePixJaCadastrada))
            );
        }

        var contaResponse = await _contaRepository.ObtemContaPorIdAsync(request.IdConta);

        if (contaResponse == null)
        {
            _logger.LogError("Conta não existe");
            return Result.Error<CriarPixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (PagamentosPix.ContaInexistente))
            );
        }

        var pix = new PixEntity()
        {
            IdPix = request.idPix,
            IdTipoPix = request.IdTipoPix,
            ChavePix = request.ChavePix,
            IdConta = request.IdConta,
            Conta = contaResponse,
            DataCriacao = DateTime.Now,
            Status = true
        };

        await _pixRepository.CriarPixAsync(pix);
        return Result.Success(new CriarPixResponse(pix.IdPix, pix.ChavePix, pix.Status));


    }
}