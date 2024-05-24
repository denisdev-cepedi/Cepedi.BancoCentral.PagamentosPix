using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers;

public class DesabilitarChavePixRequestHandler : IRequestHandler<DesabilitarChavePixRequest, Result<DesabilitarChavePixResponse>>
{
    protected readonly IPixRepository _pixRepository;
    protected readonly ILogger<DesabilitarChavePixRequestHandler> _logger;
    public DesabilitarChavePixRequestHandler(IPixRepository pixRepository, ILogger<DesabilitarChavePixRequestHandler> logger){
        _pixRepository = pixRepository;
        _logger = logger;
    }
    public async Task<Result<DesabilitarChavePixResponse>> Handle(DesabilitarChavePixRequest request, CancellationToken cancellationToken)
    {
        var pix = await _pixRepository.ObterPixByChavePixAsync(request.ChavePix);
        if (pix == null || pix.Status == false)
            return Result.Error<DesabilitarChavePixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(PagamentosPix.PixInexistente));
        pix.Desabilitar();
        await _pixRepository.AtualizarPixAsync(pix);

        return Result.Success(new DesabilitarChavePixResponse(pix.Status ? "Ativado" : "Desativado"));
    }
}