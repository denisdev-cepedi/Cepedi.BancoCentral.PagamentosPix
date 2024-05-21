using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses
{
    public class ObterListTransacoesPixResponse
    {
         public List<ObterTransacaoPixResponse> TransacoesPix { get; set; } = default!;
    }
}