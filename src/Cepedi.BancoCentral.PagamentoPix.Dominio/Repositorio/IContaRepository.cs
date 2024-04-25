
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;

public interface IContaRepository
{
    Task<ContaEntity> ObterContaByIdAsync(int idConta);
}

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio
{
      public interface IContaRepository
      {
        Task<ContaEntity> ObtemContaPorIdAsync(int IdConta);
        Task<List<ContaEntity>> ObtemContasAsync();
        Task<ContaEntity> CriarContaAsync(ContaEntity conta);
        Task<ContaEntity> AtualizarPessoaAsync(ContaEntity conta);
    }

}