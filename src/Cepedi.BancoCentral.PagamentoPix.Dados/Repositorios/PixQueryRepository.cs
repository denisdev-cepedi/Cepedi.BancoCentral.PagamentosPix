using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios.Querys;
using Cepedi.BancoCentral.PagamentoPix.Data;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;


public class PixQueryRepository : BaseDapperRepository
{

    public PixQueryRepository(IConfiguration configuration) : base(configuration) { }

   public async Task<PixEntity> ObterPixByChavePixAsyncQuery(string chavePix)
{
    var parameters = new DynamicParameters();
    parameters.Add("@ChavePix", chavePix, System.Data.DbType.String);

    var sql = @"
        SELECT 
            p.IdPix, 
            p.Numero AS codigoInstituicao,
            p.ChavePix, 
            p.IdTipoPix,
            p.Status,
            
        FROM 
            Pix p WITH (NOLOCK)
        INNER JOIN 
            Conta c WITH (NOLOCK) ON p.IdConta = c.IdConta
        WHERE 
            p.ChavePix = @ChavePix;
    ";

    var resultado = await ExecuteQueryAsync<PixEntity>(sql, parameters);
    
        return resultado.FirstOrDefault();
        
    }
}