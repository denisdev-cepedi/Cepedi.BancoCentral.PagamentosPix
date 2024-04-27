using Cepedi.BancoCentral.PagamentoPix.Api.Controllers;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Api.Tests;

public class ContaControllerTests
{
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly ILogger<ContaController> _logger = Substitute.For<ILogger<ContaController>>();
    private readonly ContaController _sut;

    public ContaControllerTests()
    {
        _sut = new ContaController(_logger, _mediator);
    }

    [Fact]
    public async Task CriarConta_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new CriarContaRequest { Conta = "0000", Agencia = "11111111111" };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new CriarContaResponse(1, 1)));

        // Act
        await _sut.CriarContaAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }
    [Fact]
    public async Task AtualizarConta_DeveEnviarRequest_Para_Mediator()
    {
        // Arrange 
        var request = new AtualizarContaRequest { Conta = "0000", Agencia = "11111111111", IdConta = 1, IdPessoa = 1 };
        _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new AtualizarContaResponse("0000", "11111111111")));

        // Act
        await _sut.AtualizarContaAsync(request);

        // Assert
        await _mediator.ReceivedWithAnyArgs().Send(request);
    }

}