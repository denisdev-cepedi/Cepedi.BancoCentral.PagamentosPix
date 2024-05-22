using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;

namespace Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio
{
    public interface IPixQueryRepository
    {
        Task<PixEntity> ObterChavePixAsync(string chavePix);
    }
}