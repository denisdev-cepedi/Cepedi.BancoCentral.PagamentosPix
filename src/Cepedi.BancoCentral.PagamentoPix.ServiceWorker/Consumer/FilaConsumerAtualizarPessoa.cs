using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Enums;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.RabbitMQ;
using MediatR;

namespace Cepedi.BancoCentral.ServiceWorker.Consumer;
public class FilaConsumerAtualizarPessoa : RabbitMQConsumer<AtualizarPessoaRequest>
{
    private readonly IServiceProvider _serviceProvider;

    public FilaConsumerAtualizarPessoa(
        IServiceProvider serviceProvider,
        IConfiguration configuration)
        : base(configuration)
    {
        _serviceProvider = serviceProvider;
    }

    public override async Task<ResultadoProcessamento> ProcessarMensagem(AtualizarPessoaRequest mensagem, int tentativa, CancellationToken cancellationToken)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            cancellationToken.ThrowIfCancellationRequested();

            var (sucesso, resultado, erro) = await mediator.Send(mensagem, cancellationToken);

            if (erro != null)
            {
                // incluir log
            }

            return sucesso switch
            {
                true => ResultadoProcessamento.Success,
                false => tentativa < 3 ? ResultadoProcessamento.TryAgain : ResultadoProcessamento.Error,
            };
        }
        catch (Exception ex)
        {

            return ResultadoProcessamento.Error;
        }
    }
}
