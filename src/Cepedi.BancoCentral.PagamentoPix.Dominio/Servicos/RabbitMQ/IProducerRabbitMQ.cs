using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Servicos.RabbitMQ
{
    public interface IProducerRabbitMQ
    {
        void SendMessage(string message);
    }
}