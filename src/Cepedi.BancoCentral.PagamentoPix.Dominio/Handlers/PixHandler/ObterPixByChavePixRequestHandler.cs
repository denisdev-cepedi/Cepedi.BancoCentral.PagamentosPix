using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;

public class ObterPixByChavePixRequestHandler : IRequestHandler<ObterPixByChavePixRequest, Result<ObterPixByChavePixResponse>>
{
    private readonly IPixRepository _pixRepository;
    public ObterPixByChavePixRequestHandler( IPixRepository pixRepository){
        _pixRepository = pixRepository;
    }
    public async Task<Result<ObterPixByChavePixResponse>> Handle(ObterPixByChavePixRequest request, CancellationToken cancellationToken)
    {
        var pix = await _pixRepository.ObterPixByChavePixAsync(request.ChavePix);

        if (pix == null){
            return Result.Error<ObterPixByChavePixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(PagamentosPix.PixInexistente));
        }

        return Result.Success(new ObterPixByChavePixResponse(pix.IdPix, pix.Conta.Numero.ToString() ,((PixEntity.TipoPix)pix.IdTipoPix).ToString(), pix.ChavePix, pix.Status ? "Ativado" : "Desativado"));
    }
}
