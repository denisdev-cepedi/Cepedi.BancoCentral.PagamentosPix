﻿using Cepedi.BancoCentral.PagamentoPix.Api.Controllers;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Api.Tests
{
    public class UserControllerTests
    {
        private readonly IMediator _mediator = Substitute.For<IMediator>();
        private readonly ILogger<UserController> _logger = Substitute.For<ILogger<UserController>>();
        private readonly UserController _sut;

        public UserControllerTests()
        {
            _sut = new UserController(_logger, _mediator);
        }

        [Fact]
        public async Task CriarUsuario_DeveEnviarRequest_Para_Mediator()
        {
            // Arrange 
            var request = new CriarUsuarioRequest { Nome = "Denis" };
            _mediator.Send(request).ReturnsForAnyArgs(Result.Success(new CriarUsuarioResponse(1, "")));

            // Act
            await _sut.CriarUsuarioAsync(request);

            // Assert
            await _mediator.ReceivedWithAnyArgs().Send(request);
        }
    }
}
