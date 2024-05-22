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
        public async Task CriarTransacaoAsync_DeveRetornarErroQuandoChavePixOrigemInexistente()
        {
            // Arrange
            _transacaoPixRepository.ObterIdPorChavePixAsync(Arg.Any<string>()).Returns(Task.FromResult(0));
            var request = new CriarTransacaoPixRequest
            {
                Valor = 100,
                Data = DateTime.Now,
                ChavePixOrigem = "5555555555",
                ChavePixDestino = "73998626051"
            };

            // Act
            var result = await _sut.Handle(request, CancellationToken.None);

            // Assert
            await _transacaoPixRepository.DidNotReceive().CriarTransacaoPixAsync(Arg.Any<TransacaoPixEntity>());
            

        }
    }
}
