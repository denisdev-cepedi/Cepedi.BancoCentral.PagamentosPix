using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses
{
    public class ObterContaBankResponse
    {
        public string Nome { get; set; } = default!;
        public string Numero { get; set; } = default!; 
        public required string Agencia { get; set; }
        public required string Conta { get; set; } = default!;
    }
}