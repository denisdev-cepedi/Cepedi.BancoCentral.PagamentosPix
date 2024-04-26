using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;

public interface IPixRepository
{
    ICollection<PixEntity> ListarPixs();
    Task<PixEntity> CriarPixAsync(PixEntity pix);
    Task<PixEntity> ObterPixByIdAsync(int id);
    Task<PixEntity> AtualizarPixAsync(PixEntity pix);
    Task<PixEntity> ObterChavePixAsync(string chavePix);

}