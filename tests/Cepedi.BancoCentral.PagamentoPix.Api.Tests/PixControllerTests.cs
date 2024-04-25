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
    public class PixControllerTests
    {
        private readonly IMediator _mediator = Substitute.For<IMediator>();
        private readonly ILogger<PixController> _logger = Substitute.For<ILogger<PixController>>();
        private readonly PixController _sut;

        public PixControllerTests()
        {
            _sut = new PixController(_logger, _mediator);
        }

        [Fact]
        public async Task CriarPix_DeveEnviarRequest_Para_Mediator()
        {
            // Arrange 
            var request = new CriarPixRequest { IdConta = 1, ChavePix = "12345678901234567890", IdTipoPix = 1 };
            //       public int idPix { get; set; }
            // public int IdConta { get; set; }
            // public string ChavePix { get; set; } = default!;
            // public int IdTipoPix { get; set; }
            // public record CriarPixResponse(int idPix, string chavePix, bool status);
            _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new CriarPixResponse(1, "12345678901234567890", true)));



            // Assert
            await _mediator.ReceivedWithAnyArgs().Send(request);
        }


    }
}