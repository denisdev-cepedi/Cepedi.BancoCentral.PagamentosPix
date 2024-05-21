using System.Linq;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers;

public class ObterPixsRequestHandler : IRequestHandler<ObterPixsRequest, Result<List<ObterPixsResponse>>>
{

    private readonly IPixRepository _pixRepository;
    private readonly IContaRepository _contaRepository;
    private readonly ILogger<ObterPixsRequestHandler> _logger;

    public ObterPixsRequestHandler(IPixRepository pixRepository, IContaRepository contaRepository , ILogger<ObterPixsRequestHandler> logger)
    {
        _pixRepository = pixRepository;
        _contaRepository = contaRepository;
        _logger = logger;
    }

    public async Task<Result<List<ObterPixsResponse>>> Handle(ObterPixsRequest request, CancellationToken cancellationToken)
    {

        var pixs = await _pixRepository.GetAllPixsAsync();


        if (pixs == null)
        {
            return Result.Error<List<ObterPixsResponse>>(new Compartilhado.Excecoes.SemResultadosExcecao());
        }

        return Result.Success(pixs.Select(x => new ObterPixsResponse(x.IdPix, x.Conta.Numero.ToString() ,x.ChavePix,((PixEntity.TipoPix)x.IdTipoPix).ToString(), x.Status ? "Ativado" : "Desativado")).ToList());}
}