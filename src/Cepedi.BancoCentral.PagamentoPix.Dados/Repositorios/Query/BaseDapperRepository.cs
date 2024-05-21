
using System.Collections;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios.Querys;

public abstract class BaseDapperRepository
{
    private readonly string _connectionString;
    protected BaseDapperRepository(IConfiguration configuration) 
    { 
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public virtual async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, DynamicParameters parameters){
        using var connection = GetConnection();
        connection.Open();

        var result = await connection.QueryAsync<T>(query, parameters);
        //fechar a conexão do banco só aguenta 30mil conexões
        connection.Close();
        return result.ToList();

    }
    private IDbConnection GetConnection(){
        var sqlConnect = new SqlConnection(_connectionString);
        return sqlConnect;
    }

}