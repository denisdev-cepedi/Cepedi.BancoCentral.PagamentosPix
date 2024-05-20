using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio
{
    public interface IPessoaRepository
    {
        Task<PessoaEntity> ObtemPessoaPorIdAsync(int IdPessoa);
        Task<List<PessoaEntity>> ObtemPessoasAsync();
        Task<PessoaEntity> CriarPessoaAsync(PessoaEntity pessoa);
        Task<PessoaEntity> AtualizarPessoaAsync(PessoaEntity pessoa);
        Task<List<PessoaEntity>> ObterPessoasAsync();
        Task<PessoaEntity> ObtemPessoaPorCpfAsync(string cpf);
        
    }
}