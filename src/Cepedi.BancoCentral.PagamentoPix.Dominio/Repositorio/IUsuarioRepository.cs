using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;

public interface IUsuarioRepository
{
    Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuario);
    Task<UsuarioEntity> ObterUsuarioAsync(int id);
    Task<UsuarioEntity> AtualizarUsuarioAsync(UsuarioEntity usuario);
}
