using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers;
public class CriarTransacaoPixRequestHandler : IRequestHandler<CriarTransacaoPixRequest, Result<CriarTransacaoPixResponse>>
{

    private readonly ILogger<CriarTransacaoPixRequestHandler> _logger;
    private readonly ITransacaoPixRepository _transacaoPixRepository;
    private readonly IPixRepository _pixRepository;

    public CriarTransacaoPixRequestHandler(ITransacaoPixRepository transacaoPixRepository, ILogger<CriarTransacaoPixRequestHandler> logger, IPixRepository pixRepository)
    {
        _transacaoPixRepository = transacaoPixRepository;
        _logger = logger;
        _pixRepository = pixRepository;

    }
    public async Task<Result<CriarTransacaoPixResponse>> Handle(CriarTransacaoPixRequest request, CancellationToken cancellationToken)
    {

        var PixOrigem = await _pixRepository.ObterPixByChavePixAsync(request.ChavePixOrigem);
        var PixDestino = await _pixRepository.ObterPixByChavePixAsync(request.ChavePixDestino);
      
        if (PixDestino == null || PixOrigem == null)
        {
            _logger.LogError("Chave Pix incorreta ou inexistente ");

            return Result.Error<CriarTransacaoPixResponse>(
                    new Compartilhado.Excecoes.PixInexistente());
        }

        if (ChavesPixIguais(PixOrigem.ChavePix, PixDestino.ChavePix))
        {
            _logger.LogError("A chave de origem e a chave de destino são iguais.");
            return Result.Error<CriarTransacaoPixResponse>(
                new Compartilhado.Excecoes.ChavesPixIguais());
        }

        var transacao = new TransacaoPixEntity()
        {
            Valor = request.Valor,
            Data = request.Data,
            ChaveDeSeguranca = GerarChaveDeSeguranca(),
            IdPixOrigem = PixOrigem.IdPix,
            IdPixDestino = PixDestino.IdPix,
            PixOrigem = PixOrigem,
            PixDestino = PixDestino,
        };

        await _transacaoPixRepository.CriarTransacaoPixAsync(transacao);

        return Result.Success(new CriarTransacaoPixResponse(transacao.IdTransacaoPix, transacao.Valor, transacao.ChaveDeSeguranca));
    }

    private static string GerarChaveDeSeguranca()
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] keyBytes = new byte[16];
            rng.GetBytes(keyBytes);
            return BytesToHexString(keyBytes);
        }
    }

    private static string BytesToHexString(byte[] bytes)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            sb.Append(b.ToString("X2"));
        }
        return sb.ToString();
    }

    private static bool ChavesPixIguais(string chavePixOrigem, string chavePixDestino)
    {
        return chavePixOrigem == chavePixDestino;
    }
}
