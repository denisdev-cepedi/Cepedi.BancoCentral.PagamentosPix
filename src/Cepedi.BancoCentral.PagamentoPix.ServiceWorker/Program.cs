using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.IoC;
using Cepedi.BancoCentral.PagamentoPix.RabbitMQ;
using Cepedi.BancoCentral.ServiceWorker;
using Cepedi.BancoCentral.ServiceWorker.Consumer;


var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.ConfigureAppDependencies(hostContext.Configuration);
        services.AddSingleton<IConsumerRabbitMQ<CriarPessoaRequest>, FilaConsumerCriarPessoa>();
        services.AddSingleton<IConsumerRabbitMQ<AtualizarPessoaRequest>, FilaConsumerAtualizarPessoa>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
