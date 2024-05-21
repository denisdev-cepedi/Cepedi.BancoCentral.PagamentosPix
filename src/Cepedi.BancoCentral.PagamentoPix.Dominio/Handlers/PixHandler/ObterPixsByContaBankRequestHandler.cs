using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers;

public class ObterPixsByContaBankRequestHandler : IRequestHandler<ObterPixsByContaBankRequest, Result<List<ObterPixsByContaBankResponse>>>
{
    private readonly ILogger<ObterPixsByContaBankRequestHandler> _logger;
    private readonly IPixRepository _pixRepository;


    public ObterPixsByContaBankRequestHandler(IPixRepository pixRepository, ILogger<ObterPixsByContaBankRequestHandler> logger){
        _pixRepository = pixRepository;
        _logger = logger;
       
    }
    
    public async Task<Result<List<ObterPixsByContaBankResponse>>> Handle(ObterPixsByContaBankRequest request, CancellationToken cancellationToken)
    {
       var pixs = await _pixRepository.GetAllPixsByBankContaAsync(request.CodigoInstituicao, request.Agencia, request.Conta);
       
       if (pixs == null){
           return Result.Error<List<ObterPixsByContaBankResponse>>(new Compartilhado.Excecoes.SemResultadosExcecao());
       }

       return Result.Success(pixs.Select(x => new ObterPixsByContaBankResponse(x.IdPix, x.ChavePix,((PixEntity.TipoPix)x.IdTipoPix).ToString(), x.Status ? "Ativado" : "Desativado")).ToList());
    }
}