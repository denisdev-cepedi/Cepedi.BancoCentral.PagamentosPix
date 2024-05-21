using System.Threading;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using OperationResult;
using Xunit;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Tests
{
    public class CriarTransacaoPixRequestHandlerTests
    {
        private readonly ITransacaoPixRepository _transacaoPixRepository = Substitute.For<ITransacaoPixRepository>();
        private readonly ILogger<CriarTransacaoPixRequestHandler> _logger = Substitute.For<ILogger<CriarTransacaoPixRequestHandler>>();
        private readonly CriarTransacaoPixRequestHandler _sut;

        public CriarTransacaoPixRequestHandlerTests()
        {
            _sut = new CriarTransacaoPixRequestHandler(_transacaoPixRepository, _logger);
        }


        [Fact]
        public async Task CriarTransacaoAsync_QuandoCriar_DeveRetornarSucesso()
        {
            // Arrange
            var request = new CriarTransacaoPixRequest
            {
                Valor = 100,
                Data = DateTime.Now,
                ChavePixOrigem = "00352442590",
                ChavePixDestino = "73998626051"
            };
            _transacaoPixRepository.ObterIdPorChavePixAsync(request.ChavePixOrigem).Returns(Task.FromResult(1));
            _transacaoPixRepository.ObterIdPorChavePixAsync(request.ChavePixDestino).Returns(Task.FromResult(2));
            _transacaoPixRepository.CriarTransacaoPixAsync(Arg.Any<TransacaoPixEntity>()).Returns(Task.CompletedTask);
            // Act
            var result = await _sut.Handle(request, CancellationToken.None);

        }
    }
}
