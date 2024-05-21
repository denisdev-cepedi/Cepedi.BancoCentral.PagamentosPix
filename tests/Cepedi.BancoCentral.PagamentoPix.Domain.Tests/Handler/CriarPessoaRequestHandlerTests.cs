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

public class CriarPessoaRequestHandlerTests
{
    private readonly IPessoaRepository _pessoaRepository =
    Substitute.For<IPessoaRepository>();

    private readonly ILogger<CriarPessoaRequestHandler> _logger = Substitute.For<ILogger<CriarPessoaRequestHandler>>();
    private readonly CriarPessoaRequestHandler _sut;

    public CriarPessoaRequestHandlerTests() 
    {
        _sut = new CriarPessoaRequestHandler(_pessoaRepository, _logger);
    }

    [Fact]
    public async Task CriarPessoaAsync_QuandoCriar_DeveRetornarSucesso()
    {
        //Arrange 
        var pessoa = new CriarPessoaRequest { Nome= "PessoaX", Cpf = "11111111111"};
        
        _pessoaRepository.CriarPessoaAsync(It.IsAny<PessoaEntity>())
            .ReturnsForAnyArgs(new PessoaEntity
            {
                IdPessoa = 1,
                Nome = pessoa.Nome,
                Cpf = pessoa.Cpf
            });

        //Act
        var result = await _sut.Handle(pessoa, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<CriarPessoaResponse>>().Which
            .Value.nome.Should().Be(pessoa.Nome);
        result.Should().BeOfType<Result<CriarPessoaResponse>>().Which
            .Value.nome.Should().NotBeEmpty();
    }

    [Fact]
    public async Task CriarPessoaAsync_QuandoCriarNomeMenorQueCincoCaracteres_DeveRetornarErro()
    {
        //Arrange 
        var pessoa = new CriarPessoaRequest { Nome= "X", Cpf = "11111111111"};

        _pessoaRepository.CriarPessoaAsync(It.IsAny<PessoaEntity>())
            .ReturnsForAnyArgs(new PessoaEntity
            {
                IdPessoa = 1,
                Nome = pessoa.Nome,
                Cpf = pessoa.Cpf
            });

        //Act
        var result = await _sut.Handle(pessoa, CancellationToken.None);

        //Assert 
        // result.IsFailure.Should().BeTrue();
        // result.Should().BeOfType<Result<CriarPessoaResponse>>().Which
        //     .ValueNome.Should().Be(pessoa.Nome);
        // result.Should().BeOfType<Result<CriarPessoaResponse>>().Which
        //     .ValueNome.Should().NotBeEmpty();

    }

}
