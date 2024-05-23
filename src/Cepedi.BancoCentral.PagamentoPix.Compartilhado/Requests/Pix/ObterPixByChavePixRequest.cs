using Cepedi.BancoCentral.PagamentoPix.Compartilhado;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;

public class ObterPixByChavePixRequest : IRequest <Result<ObterPixByChavePixResponse>>, IValida{

    public required string TipoPix { get; set; }
    public required string ChavePix { get; set; }

}