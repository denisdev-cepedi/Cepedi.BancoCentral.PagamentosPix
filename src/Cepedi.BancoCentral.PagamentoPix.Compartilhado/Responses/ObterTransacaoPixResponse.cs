using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
    public record ObterTransacaoPixResponse (int IdTransacaoPix, decimal Valor, DateTime Data, string ChaveDeSeguranca, int IdPixOrigem, int IdPixDestino);
    
        
    
