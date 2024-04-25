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

public class ExcluirPixRequestHandler : IRequestHandler<ExcluirPixRequest, Result<ExcluirPixResponse>>
{
    private readonly ILogger<ExcluirPixRequestHandler> _logger;
    private readonly IPixRepository _pixRepository;

    public async Task<Result<ExcluirPixResponse>> Handle(ExcluirPixRequest request, CancellationToken cancellationToken)
    {
       var pixResponse = await _pixRepository.ObterPixByIdAsync(request.idPix);
       if (pixResponse == null){
           return Result.Error<ExcluirPixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
               (PagamentosPix.PixInexistente))
           );
        }
        pixResponse.Desabilitar();
        await _pixRepository.AtualizarPixAsync(pixResponse);
        return Result.Success(new ExcluirPixResponse(pixResponse.Status));
    }
}
