using Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios.Querys;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;

public class PessoaQueryRespository : BaseDapperRepository
{
    public PessoaQueryRespository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<List<PessoaEntity>> ObtemPessoasAsync(string nome){
        var parameters = new DynamicParameters();
        parameters.Add("@Nome", nome, System.Data.DbType.String);
        var sql = @"SELECT 
            IdPessoa, Nome, Cpf
            FROM Pessoa WITH (NOLOCK)
            Where Nome = @Nome; 
        ";
        var retorno = await ExecuteQueryAsync<PessoaEntity> (sql, parameters);
        return retorno.ToList();
    }
}