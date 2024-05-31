using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers;

public class ObterPixByChavePixRequestHandler : IRequestHandler<ObterPixByChavePixRequest, Result<ObterPixByChavePixResponse>>
{
    private readonly IPixRepository _pixRepository;
    private readonly ILogger<ObterPixByChavePixRequestHandler> _logger;
  
    public ObterPixByChavePixRequestHandler( IPixRepository pixRepository, ILogger<ObterPixByChavePixRequestHandler> logger){
        _pixRepository = pixRepository;
        _logger = logger;
    }
    public async Task<Result<ObterPixByChavePixResponse>> Handle(ObterPixByChavePixRequest request, CancellationToken cancellationToken)
    {
        var pix = await _pixRepository.ObterPixByChavePixAsync(request.ChavePix);
        if (pix == null){
            return Result.Error<ObterPixByChavePixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(PagamentosPix.PixInexistente));
        }
        var response = new ObterPixByChavePixResponse(pix.IdPix, pix.Conta.Numero.ToString() , pix.ChavePix, ((PixEntity.TipoPix)pix.IdTipoPix).ToString(), pix.Status == true ? "Ativado" : "Desativado");
        return Result.Success(response);
    }
}