using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.BancoCentral.PagamentoPix.RabbitMQ
{
 public interface IConsumerRabbitMQ<T>
    {
        Task IniciaLeituraMensagens(CancellationToken cancellationToken);
        void Finaliza();
    }

}