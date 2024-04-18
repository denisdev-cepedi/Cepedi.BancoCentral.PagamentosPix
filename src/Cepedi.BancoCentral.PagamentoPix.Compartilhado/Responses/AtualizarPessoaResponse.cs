using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses
{
    public record AtualizarPessoaResponse(string nome, string cpf, string idConta);
}