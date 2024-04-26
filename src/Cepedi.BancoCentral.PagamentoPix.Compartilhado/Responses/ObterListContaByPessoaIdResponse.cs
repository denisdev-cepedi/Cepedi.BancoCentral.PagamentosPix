using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses
{
    public class ObterListContaByPessoaIdResponse
    {
        public List<ObterContaResponse> Contas { get; set; } = default!; 
    }
}