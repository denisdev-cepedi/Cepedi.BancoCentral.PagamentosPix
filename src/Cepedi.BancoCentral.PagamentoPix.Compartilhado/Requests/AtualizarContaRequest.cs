﻿using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using OperationResult;

public class AtualizarContaRequest: IRequest<Result<AtualizarContaResponse>>
{
 public int IdConta { get; set; }
    public int IdPessoa { get; set; }
    public string Numero { get; set; } = default!; //numero da instituição pertencedora
    public required string Agencia { get; set; }
    public required string Conta { get; set; } = default!;
    
}
