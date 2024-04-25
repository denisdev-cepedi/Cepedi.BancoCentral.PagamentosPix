using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;


namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Tests;

public class CriarPixRequestHandlerTests
{
    private readonly IContaRepository _contaRepository = 
    Substitute.For<IContaRepository>();
    private readonly IPixRepository _pixRepository =
    Substitute.For<IPixRepository>();

    private readonly ILogger<CriarPixRequestHandler> _logger =
     Substitute.For<ILogger<CriarPixRequestHandler>>();
    private readonly CriarPixRequestHandler _sut;

    public CriarPixRequestHandlerTests()
    {
        _sut = new CriarPixRequestHandler(_pixRepository, _contaRepository, _logger);
    }

    [Fact]
    public async Task CriarPixAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var pix = new CriarPixRequest { 
            ChavePix = "12345678901234567890", IdConta = 1, IdTipoPix = 1 };


        _pixRepository.CriarPixAsync(It.IsAny<PixEntity>())
            .ReturnsForAnyArgs(new PixEntity
            {
                IdPix = 1,
                IdConta = 1,
                ChavePix = "12345678901234567890",
                IdTipoPix = 1,
                DataCriacao = DateTime.Now,
                Status = true,
            });

        //Act
        var result = await _sut.Handle(pix, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<CriarPixResponse>>().Which
            .Value.chavePix.Should().Be(pix.ChavePix);
        result.Should().BeOfType<Result<CriarPixResponse>>().Which
            .Value.chavePix.Should().NotBeEmpty();
    }

}
