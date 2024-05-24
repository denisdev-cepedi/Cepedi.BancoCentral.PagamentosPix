using Cepedi.BancoCentral.PagamentoPix.Api.Controllers;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;
using OperationResult;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;

namespace Cepedi.BancoCentral.PagamentoPix.Api.Tests
{
    public class PixControllerTests
    {
        // Cria substitutos (mocks) para as dependências do controlador
        private readonly IMediator _mediator = Substitute.For<IMediator>();
        private readonly ILogger<PixController> _logger = Substitute.For<ILogger<PixController>>();
        private readonly PixController _sut;

        // Inicializa o controlador com as dependências mockadas
        public PixControllerTests()
        {
            _sut = new PixController(_logger, _mediator);
        }

        [Fact(DisplayName = "CriarpixRequet deve enviar request para mediator e retornar resposta correta")]
        public async Task CriarPix_DeveEnviarRequest_Para_Mediator()
        {
            // Arrange: Configura o estado inicial do teste
            // Cria uma instância da requisição com dados de exemplo
            var request = new CriarPixRequest()
            {
                CodigoInstituicao = "001",
                Agencia = "00001",
                Conta = "00000001",
                TipoPix = "1",
                ChavePix = "06931680218"
            };
            
            // Cria uma instância da resposta esperada
            var response = new CriarPixResponse(1, "CPF", "06931680218", "Ativo");
            
            // Configura o mock do mediador para retornar um resultado de sucesso
            _mediator.Send(request).ReturnsForAnyArgs(Result.Success(response));

            // Act: Executa a ação que estamos testando
            await _sut.CriarPixAsync(request);

            // Assert: Verifica se a ação produziu o resultado esperado
            // Verifica se o método Send do mediador foi chamado com a requisição esperada
            await _mediator.ReceivedWithAnyArgs().Send(request);
        }

    

        //ObterPixByChavePixRequest Celular, Cpf, Email, TELEFONE
        [Fact(DisplayName = "ObterPixByRequet deve enviar request para mediator e Obter O pix")]
        public async Task ObterPixByChavePix_DeveEnviarRequest_Para_Mediator(){
            // Arrange: Configura o estado inicial do teste
            //Cruar uma instância da requisição com dados de exemplo
            var request = new ObterPixByChavePixRequest(){
                TipoPix = "1",
                ChavePix = "06931680218"
            };

            //Cruar uma instância da resposta esperada
            var response = new ObterPixByChavePixResponse(1, "1", "CPF", "06931680218", "Ativo");

            //Configura o mock do mediador para retornar um resultado de sucesso
            _mediator.Send(request).ReturnsForAnyArgs(Result.Success(response));

            //Act: Executa a ação que estamos testando
            await _sut.ObterPixsByChavePixAsync(request);

            //Assert: Verifica se a ação produziu o resultado esperado
            //Verifica se o método Send do mediador foi chamado com a requisição esperada
            await _mediator.ReceivedWithAnyArgs().Send(request);
        }
        //ObterPixByContaBankRequest

        [Fact(DisplayName ="ObterPixByContaBankRequest deve enviar request para mediator e Obter O pix")]
        public async Task ObterPixsByContaBank_DeveEnviarRequest_Para_Mediator(){
            // Arrange: Configura o estado inicial do teste
            //Cruar uma instância da requisição com dados de exemplo
            var request = new ObterPixsByContaBankRequest(){
                CodigoInstituicao = "001",
                Agencia = "00001",
                Conta = "00000001",
            };

            //Cruar uma instância da resposta esperada
            var response = new List<ObterPixsByContaBankResponse>(){
                new ObterPixsByContaBankResponse(1,  "CPF", "06931680218", "Ativo")
            };

            //Configura o mock do mediador para retornar um resultado de sucesso
            _mediator.Send(request).ReturnsForAnyArgs(Result.Success(response));
            

            //Act: Executa a ação que estamos testando
            await _sut.ObterPixsByContaBankAsync(request);

            //Assert: Verifica se a ação produziu o resultado esperado
            //Verifica se o método Send do mediador foi chamado com a requisição esperada
            await _mediator.ReceivedWithAnyArgs().Send(request);


        }
        //ObterPixsRequest
        [Fact(DisplayName = "ObterPixsRequest deve enviar request para mediator e Obter O pix")]
        public async Task ObterPixs_DeveEnviarRequest_Para_Mediator(){
            // Arrange: Configura o estado inicial do teste
            //Cruar uma instância da requisição com dados de exemplo
            var request = new ObterPixsRequest(){};

            //Cruar uma instância da resposta esperada
            var response = new List<ObterPixsResponse>(){
                new ObterPixsResponse(1, "1", "CPF", "06931680218", "Ativo")
            };

            //Configura o mock do mediador para retornar um resultado de sucesso
            _mediator.Send(request).ReturnsForAnyArgs(Result.Success(response));


            //Act: Executa a ação que estamos testando
            await _sut.ObterPixsAsync(request);

            //Assert: Verifica se a ação produziu o resultado esperado
            //Verifica se o método Send do mediador foi chamado com a requisição esperada
            await _mediator.ReceivedWithAnyArgs().Send(request);

        }
        //DesabilitarChavePixRequest
        [Fact(DisplayName = "DesabilitarChavePixRequest deve enviar request para mediator e Obter O pix")]
        public async Task DesabilitarChavePix_DeveEnviarRequest_Para_Mediator(){
            // Arrange: Configura o estado inicial do teste
            //Cruar uma instância da requisição com dados de exemplo
            var request = new DesabilitarChavePixRequest(){
                TipoPix = "1",
                ChavePix = "06931680218"
            };

            //Cruar uma instância da resposta esperada
            var response = new DesabilitarChavePixResponse("Desativado");

            //Configura o mock do mediador para retornar um resultado de sucesso
            _mediator.Send(request).ReturnsForAnyArgs(Result.Success(response));


            //Act: Executa a ação que estamos testando
            await _sut.DesabilitarChavePixAsync(request);

            //Assert: Verifica se a ação produziu o resultado esperado
            //Verifica se o método Send do mediador foi chamado com a requisição esperada
            await _mediator.ReceivedWithAnyArgs().Send(request);

        }
    }

  

    
}
