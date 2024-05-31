using Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;

public interface IPixRepository
{
    Task<ICollection<PixEntity>> GetAllPixsAsync();
    Task<ICollection<PixEntity>> GetAllPixsByBankContaAsync(string codigoInstituicao, string agencia, string conta);
    Task<PixEntity> CriarPixAsync(PixEntity pix);
    Task<PixEntity> AtualizarPixAsync(PixEntity pix);
    Task<PixEntity> ObterPixByChavePixAsync(string chavePix);
   
}