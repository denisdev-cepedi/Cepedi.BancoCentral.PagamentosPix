
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio.Queries;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Dapper;
using Microsoft.Extensions.Configuration;
 
namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios.Queries;

public class TransacaoPixQueryRepository : BaseDapperRepository, ITransacaoPixQueryRepository
{
    public TransacaoPixQueryRepository(IConfiguration configuration) 
        : base(configuration)
    {
    }

    public async Task<List<TransacaoPixEntity>> ObterTransacaoPixAsync(string chaveSeguranca)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@ChaveSeguranca", chaveSeguranca, System.Data.DbType.String);

        var sql = @"SELECT 
                        Valor, 
                        Data,
                        ChaveDeSeguranca
                    FROM TransacaoPix WITH(NOLOCK)
                    Where
                        ChaveDeSeguranca = @ChaveSeguranca";

        var retorno = await ExecuteQueryAsync
            <TransacaoPixEntity>(sql, parametros);

        return retorno.ToList();
    }
}