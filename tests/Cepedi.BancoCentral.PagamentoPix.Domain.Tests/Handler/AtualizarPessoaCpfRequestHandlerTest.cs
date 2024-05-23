using System.Threading;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using OperationResult;
using Xunit;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Tests
{
    public class AtualizarPessoaCpfRequestHandlerTest
    {
        private readonly IPessoaRepository _pessoaRepository = Substitute.For<IPessoaRepository>();
        private readonly ILogger<AtualizarPessoaCpfRequestHandler> _logger = Substitute.For<ILogger<AtualizarPessoaCpfRequestHandler>>();
        private readonly AtualizarPessoaCpfRequestHandler _sut;
        private readonly AtualizarPessoaCpfRequestValidator _validator;

        public AtualizarPessoaCpfRequestHandlerTest()
        {
            _sut = new AtualizarPessoaCpfRequestHandler(_pessoaRepository, _logger);
            _validator = new AtualizarPessoaCpfRequestValidator();
        }

        [Fact]
        public async Task AtualizarPessoaCpfAsync_QuandoAtualizarPessoaInexistente_DeveRetornarErro()
        {
            //Arrange
            var request = new AtualizarPessoaCpfRequest { Cpf = "99486401012", NovoCpf = "62882300069" };

            _pessoaRepository.ObtemPessoaPorCpfAsync(
                request.Cpf).Returns(Task.FromResult<PessoaEntity>(null));//Simular uma pessoa nao encontrada
            
            var validationResult = await _validator.ValidateAsync(request);
            // Act
            var result = await _sut.Handle(request, CancellationToken.None);
            //Assert 
            
            result.IsSuccess.Should().BeFalse();
            result.Value.Should().BeNull(); 
            // result.Errors.Should().Contain("Pessoa não encontrada");
            // result.Message.Should().Be("Pessoa não encontrada");
            // result.IsSuccess().Should().BeFalse();
            // result.Error.Should().BeOfType<ExcecaoAplicacao>();
            // result.Error.Mensagem.Should().Be(PagamentosPix.PessoaInexistente);
        }

    }
}
