
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;


namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio
{
      public interface IContaRepository
      {
        Task<ContaEntity> ObtemContaPorIdAsync(int IdConta);
        Task<List<ContaEntity>> ObtemContasAsync(int IdPessoa);
        Task<ContaEntity> CriarContaAsync(ContaEntity conta);
        Task<ContaEntity> AtualizarContaAsync(ContaEntity conta);

        Task<List<ContaEntity>> ObterContasByCpfAsync(string cpf);

        Task<ContaEntity> ObterContaBankAsync(int Agencia, int Conta, int Numero);
    }

}