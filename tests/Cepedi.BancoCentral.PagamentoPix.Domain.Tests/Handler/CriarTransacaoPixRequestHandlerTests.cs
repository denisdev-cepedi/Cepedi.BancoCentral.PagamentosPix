using System;
using System.Threading;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
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
        private readonly IPixRepository _pixRepository = Substitute.For<IPixRepository>();
        private readonly CriarTransacaoPixRequestHandler _sut;

        public CriarTransacaoPixRequestHandlerTests()
        {
            _sut = new CriarTransacaoPixRequestHandler(_transacaoPixRepository, _logger, _pixRepository);
        }

        [Fact]
        public async Task CriarTransacaoAsync_DeveRetornarErroQuandoChavePixOrigemInexistente()
        {
            // Arrange
            _pixRepository.ObterPixByChavePixAsync("5555555555").Returns((PixEntity)null);
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
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public async Task CriarTransacaoAsync_DeveRetornarErroQuandoChavePixDestinoInexistente()
        {
            // Arrange
            var pixOrigem = new PixEntity { ChavePix = "5555555555", IdPix = 1, Conta = Substitute.For<ContaEntity>() };
            _pixRepository.ObterPixByChavePixAsync("5555555555").Returns(pixOrigem);
            _pixRepository.ObterPixByChavePixAsync("73998626051").Returns((PixEntity)null);
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
            result.IsSuccess.Should().BeFalse();
            //result.Error.Should().BeOfType<PixInexistente>();
        }

        [Fact]
        public async Task CriarTransacaoAsync_DeveRetornarErroQuandoChavesPixSaoIguais()
        {
            // Arrange
            var pix = new PixEntity { ChavePix = "5555555555", IdPix = 1, Conta = Substitute.For<ContaEntity>() };
            _pixRepository.ObterPixByChavePixAsync("5555555555").Returns(pix);
            var request = new CriarTransacaoPixRequest
            {
                Valor = 100,
                Data = DateTime.Now,
                ChavePixOrigem = "5555555555",
                ChavePixDestino = "5555555555"
            };

            // Act
            var result = await _sut.Handle(request, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeFalse();
            //result.Error.Should().BeOfType<ChavesPixIguais>();
             //result.Value.Descricao.Should().Be(100);
        }

        [Fact]
        public async Task CriarTransacaoAsync_DeveCriarTransacaoComSucesso()
        {
            // Arrange
            var pixOrigem = new PixEntity { ChavePix = "5555555555", IdPix = 1, Conta = Substitute.For<ContaEntity>() };
            var pixDestino = new PixEntity { ChavePix = "73998626051", IdPix = 2, Conta = Substitute.For<ContaEntity>() };
            _pixRepository.ObterPixByChavePixAsync("5555555555").Returns(pixOrigem);
            _pixRepository.ObterPixByChavePixAsync("73998626051").Returns(pixDestino);
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
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Valor.Should().Be(100);
            await _transacaoPixRepository.Received(1).CriarTransacaoPixAsync(Arg.Any<TransacaoPixEntity>());
        }
    }
}
