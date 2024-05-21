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
    }
}