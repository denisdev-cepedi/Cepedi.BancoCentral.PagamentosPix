using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.RabbitMQ;
using Cepedi.BancoCentral.ServiceWorker.Consumer;

namespace Cepedi.BancoCentral.ServiceWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConsumerRabbitMQ<CriarPessoaRequest> _criaPessoaConsumer;
    private readonly IConsumerRabbitMQ<AtualizarPessoaRequest> _atualizaPessoaConsumer;//Verificar se pode colocar mais de um

    public Worker(ILogger<Worker> logger,
        IConsumerRabbitMQ<CriarPessoaRequest> criaPessoaConsumer,
        IConsumerRabbitMQ<AtualizarPessoaRequest> atualizaPessoaConsumer)
    {
        _logger = logger;
        _criaPessoaConsumer = criaPessoaConsumer;
        _atualizaPessoaConsumer = atualizaPessoaConsumer;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            stoppingToken.Register(Finaliza);

            return Inicia(stoppingToken);
        }
        catch(OperationCanceledException ex)
        {
            return Task.FromCanceled(stoppingToken);
        }
        catch(Exception ex)
        {
            _logger.LogError("OCorreu um erro");
            return Task.FromException(ex);
        }
      
    }

    private Task Inicia(CancellationToken stoppingToken)
    {
        return Task.WhenAll(_criaPessoaConsumer.IniciaLeituraMensagens(stoppingToken),
            _atualizaPessoaConsumer.IniciaLeituraMensagens(stoppingToken));
    }

    private void Finaliza()
    {
        _criaPessoaConsumer.Finaliza();
        _atualizaPessoaConsumer.Finaliza();	
    }
}
