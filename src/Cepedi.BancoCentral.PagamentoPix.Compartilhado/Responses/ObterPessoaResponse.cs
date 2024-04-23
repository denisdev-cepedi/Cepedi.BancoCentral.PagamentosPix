using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses
{
    public class ObterPessoaResponse
    {
        public int IdPessoa { get; set; }
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public int IdConta { get; set; } 
    }
}