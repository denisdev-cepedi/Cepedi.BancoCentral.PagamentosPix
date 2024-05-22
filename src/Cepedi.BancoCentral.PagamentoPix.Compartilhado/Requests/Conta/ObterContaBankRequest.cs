using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;

public class ObterContaBankRequest : IRequest<Result<ObterContaBankResponse>>
{

    public int Agencia { get; set; }
    public int Conta { get; set; }

    public int Numero { get; set; }

    
    public ObterContaBankRequest(int Agencia, int Conta, int Numero)
    {
        this.Agencia = Agencia;
        this.Conta = Conta;
        this.Numero = Numero;
        
    }


}
