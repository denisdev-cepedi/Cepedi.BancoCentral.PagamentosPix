using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio
{
    public interface IUnitOfWork: IDisposable
    {
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);

        IRepository<T> Repository<T>() 
            where T: class;
    }
}