using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using static Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades.PixEntity;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers;

public class CriarPixRequestHandler : IRequestHandler<CriarPixRequest, Result<CriarPixResponse>>
{
    private readonly IPixRepository _pixRepository;
    private readonly ILogger<CriarPixRequestHandler> _logger;
    private readonly IContaRepository _contaRepository;

    public CriarPixRequestHandler(IPixRepository pixRepository, ILogger<CriarPixRequestHandler> logger, IContaRepository contaRepository)
    {
        _pixRepository = pixRepository;
        _logger = logger;
        _contaRepository = contaRepository;
    }

    public async Task<Result<CriarPixResponse>> Handle(CriarPixRequest request, CancellationToken cancellationToken)
    {

        var pix = await _pixRepository.ObterPixByChavePixAsync(request.ChavePix);

        if (pix == null)
        {
            var conta = await _contaRepository.ObterContaBankAsync(request.CodigoInstituicao, request.Agencia, request.Conta);
            if (conta == null)
            {
                return Result.Error<CriarPixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                    PagamentosPix.ContaInexistente
                ));       
            }

            if(request.TipoPix == "1"){

                if(ValidarCpfVinculadoAConta(request, conta.Pessoa.Cpf)!){
                    return Result.Error<CriarPixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                    PagamentosPix.CpfNaoVinculado));   
                }
                
            }
            
            var pixEntity = new PixEntity
            {
                IdConta = conta.IdConta,
                Conta = conta,
                IdTipoPix = int.Parse(request.TipoPix),
                ChavePix = request.ChavePix,
                Status = true,
                DataCriacao = DateTime.Now
            };

            await _pixRepository.CriarPixAsync(pixEntity);
            return Result.Success(new CriarPixResponse(pixEntity.IdPix, pixEntity.IdTipoPix.ToString(), pixEntity.ChavePix, pixEntity.Status ? "Ativado" : "Desativado"));
        }
        
        if (pixContaDesativado(request, pix))
        {
            pix.Ativar();
            await _pixRepository.AtualizarPixAsync(pix);
            return Result.Success(new CriarPixResponse(pix.IdPix, pix.IdTipoPix.ToString(), pix.ChavePix, pix.Status == true ? "Ativado" : "Desativado"));
        }

        return Result.Error<CriarPixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
            PagamentosPix.ChavePixJaCadastrada
        ));

    }

    private bool pixContaDesativado(CriarPixRequest request, PixEntity pix)
    {
        return pix.Status == false && pix.IdTipoPix == int.Parse(request.TipoPix) && pix.ChavePix == request.ChavePix;
    }

    private bool ValidarCpfVinculadoAConta(CriarPixRequest request, string cpf){

        if(cpf == request.ChavePix){
            return true;
        }
        return false;
    }
}