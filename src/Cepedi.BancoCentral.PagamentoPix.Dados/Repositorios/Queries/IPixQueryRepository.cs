using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios.Queries
{
    public interface IPixQueryRepository
    {
        Task<PixEntity> ObterChavePixAsync(string chavePix);
    }
}