using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.PagamentoPix.Api.Controllers;
[ApiController]
[Route("BancoCentralPagamentoPix/v1/Pixs")]
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

    [HttpGet]
    [ProducesResponseType(typeof(ObterPixsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ObterPixsResponse>>> ObterPixsAsync(
        [FromQuery] ObterPixsRequest request) => await SendCommand(request);

    [HttpPost]
    [ProducesResponseType(typeof(CriarPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarPixResponse>> CriarPixAsync(
        [FromBody] CriarPixRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(ExcluirPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ExcluirPixResponse>> ExcluirPixAsync(
        [FromBody] ExcluirPixRequest request) => await SendCommand(request);

}