using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;

public class ObterPixByChavePixRequestHandler : IRequestHandler<ObterPixByChavePixRequest, Result<ObterPixByChavePixResponse>>
{
    private readonly IPixRepository _pixRepository;
    private readonly IContaRepository _contaRepository;
    private readonly ILogger<ObterPixByChavePixRequestHandler> _logger;
    public ObterPixByChavePixRequestHandler( IPixRepository pixRepository, ILogger<ObterPixByChavePixRequestHandler> logger, IContaRepository contaRepository){
        _pixRepository = pixRepository;
        _logger = logger;
        _contaRepository = contaRepository;
    }
    public async Task<Result<ObterPixByChavePixResponse>> Handle(ObterPixByChavePixRequest request, CancellationToken cancellationToken)
    {
        var pix = await _pixRepository.ObterPixByChavePixAsync(request.ChavePix);
        var conta = await _contaRepository.ObtemContaPorIdAsync(pix.IdConta);
        pix.Conta = conta;
        if (pix == null){
            return Result.Error<ObterPixByChavePixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(PagamentosPix.PixInexistente));
        }

        return Result.Success(new ObterPixByChavePixResponse(pix.IdPix, pix.Conta.Numero.ToString() ,((PixEntity.TipoPix)pix.IdTipoPix).ToString(), pix.ChavePix, pix.Status ? "Ativado" : "Desativado"));
    }
}
