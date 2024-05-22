using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios.Queries
{
    public class PixQueryRepository : BaseDapperRepository, IPixQueryRepository
    {
        public PixQueryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PixEntity> ObterChavePixAsync(string chavePix)
        {
            var parametros = new DynamicParameters();

            parametros.Add("@chavePix", chavePix, System.Data.DbType.String);

            var sql = @"SELECT
                        IdPix, IdConta, ChavePix
                        FROM Pix
                        WHERE
                           ChavePix=@chavePix";

            var retorno = await ExecuteQueryAsync
                <PixEntity>(sql, parametros);
           
            return retorno.FirstOrDefault();

        }
    }
}