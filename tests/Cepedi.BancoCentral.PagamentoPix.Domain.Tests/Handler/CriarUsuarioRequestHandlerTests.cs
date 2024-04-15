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

public class CriarUsuarioRequestHandlerTests
{
    private readonly IUsuarioRepository _usuarioRepository =
    Substitute.For<IUsuarioRepository>();
    private readonly ILogger<CriarUsuarioRequestHandler> _logger = Substitute.For<ILogger<CriarUsuarioRequestHandler>>();
    private readonly CriarUsuarioRequestHandler _sut;

    public CriarUsuarioRequestHandlerTests()
    {
        _sut = new CriarUsuarioRequestHandler(_usuarioRepository, _logger);
    }

    [Fact]
    public async Task CriarUsuarioAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var usuario = new CriarUsuarioRequest { Nome= "Denis" };
        _usuarioRepository.CriarUsuarioAsync(It.IsAny<UsuarioEntity>())
            .ReturnsForAnyArgs(new UsuarioEntity());

        //Act
        var result = await _sut.Handle(usuario, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<CriarUsuarioResponse>>().Which
            .Value.nome.Should().Be(usuario.Nome);
        result.Should().BeOfType<Result<CriarUsuarioResponse>>().Which
            .Value.nome.Should().NotBeEmpty();
    }

}
