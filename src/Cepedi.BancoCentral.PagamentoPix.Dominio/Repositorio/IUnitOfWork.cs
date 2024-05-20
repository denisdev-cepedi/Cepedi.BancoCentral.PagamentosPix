namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
public interface IUnitOfWork : IDisposable
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);

    IRepository<T> Repository<T>()
        where T: class;
}
