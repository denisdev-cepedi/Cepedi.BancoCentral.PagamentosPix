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

public class AtualizarPessoaNomeRequestHandlerTests
{
    private readonly IPessoaRepository _pessoaRepository =
    Substitute.For<IPessoaRepository>();
    private readonly ILogger<AtualizarPessoaNomeRequestHandler> _logger = 
    Substitute.For<ILogger<AtualizarPessoaNomeRequestHandler>>();
    private readonly AtualizarPessoaNomeRequestHandler _sut;

    public AtualizarPessoaNomeRequestHandlerTests()
    {
        _sut = new AtualizarPessoaNomeRequestHandler(_pessoaRepository, _logger);
    }

    [Fact]
    public async Task AtualizarPessoaNomeAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var pessoa = new AtualizarPessoaNomeRequest { Nome= "PessoaY", Cpf = "11111111111"}; 
        var pessoaEntity = new PessoaEntity {  Nome = "PessoaX", Cpf = "11111111111"};
        _pessoaRepository.ObtemPessoaPorCpfAsync(It.IsAny<String>()).ReturnsForAnyArgs(pessoaEntity);
        _pessoaRepository.AtualizarPessoaAsync(Arg.Any<PessoaEntity>()).ReturnsForAnyArgs(info => info.Arg<PessoaEntity>()); // Corrija a inicialização para corresponder ao construtor de PessoaEntity

        //Act
        var result = await _sut.Handle(pessoa, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<AtualizarPessoaResponse>>().Which
            .Value.nome.Should().Be(pessoa.Nome);

        result.Should().BeOfType<Result<AtualizarPessoaResponse>>().Which
            .Value.nome.Should().NotBeEmpty();
    }
    

}
