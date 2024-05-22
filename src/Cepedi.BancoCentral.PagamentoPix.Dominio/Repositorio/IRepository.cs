using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio
{
    public interface IRepository<T> 
        where T : class
        {
            Task<T> AdicionarAsync(T entidade, CancellationToken cancellationToken);

            T Atualizar(T entidade);
        }
    
}