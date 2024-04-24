using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;

public interface IContaRepository
{
    Task<ContaEntity> ObterContaByIdAsync(int idConta);
}