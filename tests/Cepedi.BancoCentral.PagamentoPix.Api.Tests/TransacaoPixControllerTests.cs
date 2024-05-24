using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Api.Controllers;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;
using Xunit;

namespace Cepedi.BancoCentral.PagamentoPix.Api.Tests
{
    public class TransacaoPixControllerTests
    {
        private readonly IMediator _mediator = Substitute.For<IMediator>();
        private readonly ILogger<TransacaoPixController> _logger = Substitute.For<ILogger<TransacaoPixController>>();
        private readonly TransacaoPixController _sut;

        public TransacaoPixControllerTests()
        {
            _sut = new TransacaoPixController(_logger, _mediator);
        }

        [Fact(DisplayName = "Ao criar Transacao Pix deve retornar OK quando request é bem-sucedida")]
        public async Task CriarTransacaoAsync_DeveRetornarOkQuandoRequestEBemSucedida()
        {
            // Arrange
            var request = new CriarTransacaoPixRequest { Valor = 100, Data = DateTime.Now, ChavePixOrigem = "5555555555", ChavePixDestino = "73998626051" };
            var response = new CriarTransacaoPixResponse (1, 100, "ValorAleatorioGeradoAutomaticamente");

            // Act
           _mediator.Send(request).ReturnsForAnyArgs(Result.Success(response));

            await _sut.CriarTransacaoAsync(request);

            // Assert
             await _mediator.ReceivedWithAnyArgs().Send(request);
        }
    }
}
