using Cepedi.BancoCentral.PagamentoPix.Api.Controllers;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Api.Tests
{
    public class PessoaControllerTests
    {
        private readonly IMediator _mediator = Substitute.For<IMediator>();
        private readonly ILogger<PessoaController> _logger = Substitute.For<ILogger<PessoaController>>();
        private readonly PessoaController _sut;

        public PessoaControllerTests()
        {
            _sut = new PessoaController(_logger, _mediator);
        }

        [Fact (DisplayName = "Criar pessoa deve enviar request para mediator")]
        public async Task CriarPessoa_DeveEnviarRequest_Para_Mediator()
        {
            // Arrange 
            var request = new CriarPessoaRequest { Nome = "Lorena", Cpf = "11111111111" };
            _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new CriarPessoaResponse(1, "Lorena")));

            // Act
            await _sut.CriarPessoaAsync(request);

            // Assert
            await _mediator.ReceivedWithAnyArgs().Send(request);
        }

    }
}