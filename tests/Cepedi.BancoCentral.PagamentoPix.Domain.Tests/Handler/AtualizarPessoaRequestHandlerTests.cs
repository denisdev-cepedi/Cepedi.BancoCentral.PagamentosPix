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

public class AtualizarPessoaRequestHandlerTests
{
    private readonly IPessoaRepository _pessoaRepository =
    Substitute.For<IPessoaRepository>();
    private readonly ILogger<AtualizarPessoaRequestHandler> _logger = Substitute.For<ILogger<AtualizarPessoaRequestHandler>>();
    private readonly AtualizarPessoaRequestHandler _sut;

    public AtualizarPessoaRequestHandlerTests()
    {
        _sut = new AtualizarPessoaRequestHandler(_pessoaRepository, _logger);
    }

    [Fact]
    public async Task AtualizarPessoaAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var pessoa = new AtualizarPessoaRequest { Nome= "PessoaY", Cpf = "11111111111"}; 
        var pessoaEntity = new PessoaEntity {  Nome = "PessoaY", Cpf = "11111111111"};
        _pessoaRepository.ObtemPessoaPorIdAsync(It.IsAny<int>()).ReturnsForAnyArgs(pessoaEntity);
        _pessoaRepository.AtualizarPessoaAsync(Arg.Any<PessoaEntity>()).ReturnsForAnyArgs(info => info.Arg<PessoaEntity>()); // Corrija a inicialização para corresponder ao construtor de PessoaEntity

        //Act
        var result = await _sut.Handle(pessoa, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<AtualizarPessoaResponse>>().Which
            .Value.nome.Should().Be(pessoa.Nome);

        result.Should().BeOfType<Result<AtualizarPessoaResponse>>().Which
            .Value.nome.Should().NotBeEmpty();
    }

    // public async Task AtualizarPessoaAsync_QuandoAtualizar_DeveRetornarSucesso()
    // {
    //     //Arrange 
    //     var pessoa = new AtualizarPessoaRequest { IdConta = "1", Nome= "PessoaY", Cpf = "11111111111", IdConta = "1" };
    //     var pessoaEntity = new PessoaEntity    { Nome = "PessoaZ", Cpf = "11111111111", IdConta = "1" };
    //     _pessoaRepository.ObtemPessoaPorIdAsync(It.IsAny<int>()).ReturnsForAnyArgs(new PessoaEntity(
    //        pessoaEntity.Nome, pessoaEntity.Cpf, pessoaEntity.IdConta
    //     ));
    //     _pessoaRepository.AtualizarPessoaAsync(It.IsAny<PessoaEntity>())
    //         .ReturnsForAnyArgs(new PessoaEntity
    //         {
    //             Nome = pessoa.Nome,
    //             Cpf = pessoa.Cpf,
    //             IdConta = pessoa.IdConta
    //         });
    //     //Act
    //     var result = await _sut.Handle(pessoa, CancellationToken.None);

    //     //Assert 
    //     result.Should().BeOfType<Result<AtualizarPessoaResponse>>().Which
    //         .Value.nome.Should().Be(pessoa.Nome);

    //     result.Should().BeOfType<Result<AtualizarPessoaResponse>>().Which
    //         .Value.nome.Should().NotBeEmpty();
    // }

}
