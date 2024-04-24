using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handler;

public class ObterPixsRequestHandler : IRequestHandler<ObterPixsRequest, Result<List<ObterPixsResponse>>>
{
    private readonly ILogger<ObterPixsRequestHandler> _logger;
    private readonly IPixRepository _pixRepository;

    public ObterPixsRequestHandler(IPixRepository pixRepository, ILogger<ObterPixsRequestHandler> logger)
    {
        _pixRepository = pixRepository;
        _logger = logger;
    }

    public async Task<Result<List<ObterPixsResponse>>> Handle(ObterPixsRequest request, CancellationToken cancellationToken)
    {
        var pixs = _pixRepository.ListarPixs();
        if (pixs == null){
            return Result.Error<List<ObterPixsResponse>>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (PagamentosPix.SemResultados))
            );
        }
        // ObterPixsResponse(int idPix, int idConta, string chavePix, bool status, DateTime dataCriacao);
        return Result.Success(pixs.Select(x => new ObterPixsResponse(x.IdPix, x.IdConta, x.ChavePix, x.Status, x.DataCriacao)).ToList());

    }
}