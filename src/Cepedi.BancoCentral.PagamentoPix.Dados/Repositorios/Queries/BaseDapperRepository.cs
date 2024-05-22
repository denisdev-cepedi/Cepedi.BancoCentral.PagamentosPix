using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios.Queries
{
    public class BaseDapperRepository
    {
        private readonly string? _connectionString;

        protected BaseDapperRepository(IConfiguration configuration)
        {
            _connectionString = 
                configuration.GetConnectionString("DefaultConnection");
        }

        public virtual async Task<IEnumerable<T>> 
            ExecuteQueryAsync<T>(string query, DynamicParameters parametros)
        {
            using var conn = GetConnection();
            conn.Open();

            var result = await conn.QueryAsync<T>(query, parametros);

            conn.Close();

            return result.ToList();
        }

        private IDbConnection GetConnection()
        {
            var sqlConnect = new SqlConnection(_connectionString);
            return sqlConnect;
        }
    }
}