using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.PagamentoPix.Api.Controllers;
public class PixController : BaseController
{
    private readonly ILogger<PixController> _logger;
    private readonly IMediator _mediator;

    public PixController(
        ILogger<PixController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarPixResponse>> CriarPixAsync(
        [FromBody] CriarPixRequest request) => await SendCommand(request);
    
    // [HttpPut]
    // [ProducesResponseType(typeof(AtualizarPixResponse), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    // public async Task<ActionResult<AtualizarPixResponse>> AtualizarPixAsync(
    //     [FromBody] AtualizarPixRequest request) => await SendCommand(request);
    // )
}