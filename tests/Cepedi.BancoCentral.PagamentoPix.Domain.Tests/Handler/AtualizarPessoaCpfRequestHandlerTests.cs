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

public class AtualizarPessoaCpfRequestHandlerTests
{
    private readonly IPessoaRepository _pessoaRepository =
    Substitute.For<IPessoaRepository>();
    private readonly ILogger<AtualizarPessoaCpfRequestHandler> _logger = 
    Substitute.For<ILogger<AtualizarPessoaCpfRequestHandler>>();
    private readonly AtualizarPessoaCpfRequestHandler _sut;

    public AtualizarPessoaCpfRequestHandlerTests()
    {
        _sut = new AtualizarPessoaCpfRequestHandler(_pessoaRepository, _logger);
    }

    [Fact]
    public async Task AtualizarPessoaAsync_QuandoAtualizar_DeveRetornarSucesso()
    {
        //Arrange 
        var pessoa = new AtualizarPessoaCpfRequest { Cpf = "98558796009", NovoCpf = "06247614012"}; 
        var pessoaEntity = new PessoaEntity {  Nome = "PessoaX", Cpf = "84197336012"};
        _pessoaRepository.ObtemPessoaPorCpfAsync(It.IsAny<string>()).ReturnsForAnyArgs(pessoaEntity);
        _pessoaRepository.AtualizarPessoaAsync(Arg.Any<PessoaEntity>()).ReturnsForAnyArgs(info => info.Arg<PessoaEntity>()); // Corrija a inicialização para corresponder ao construtor de PessoaEntity

        //Act
        var result = await _sut.Handle(pessoa, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<AtualizarPessoaResponse>>().Which
            .Value.cpf.Should().Be(pessoa.Cpf);

        result.Should().BeOfType<Result<AtualizarPessoaResponse>>().Which
            .Value.cpf.Should().NotBeEmpty();
    }

}
