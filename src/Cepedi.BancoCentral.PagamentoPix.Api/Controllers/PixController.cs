using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cepedi.BancoCentral.PagamentoPix.Api.Controllers;
[ApiController]
[Route("[controller]/v1/Pixs")]
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
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<List<ObterPixsResponse>>> ObterPixsAsync() => await SendCommand(new ObterPixsRequest());

   
    [HttpPost]
    [ProducesResponseType(typeof(CriarPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<CriarPixResponse>> CriarPixAsync(
        [FromBody] CriarPixRequest request) => await SendCommand(request);

    [HttpGet ("ContaBank")]
    [ProducesResponseType(typeof(ObterPixsByContaBankResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<List<ObterPixsByContaBankResponse>>> ObterPixsByContaBankAsync(
        [FromBody] ObterPixsByContaBankRequest request) => await SendCommand(request);

    
    [HttpGet("ChavePix")]
    [ProducesResponseType(typeof(ObterPixByChavePixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ObterPixByChavePixResponse>> ObterPixsByChavePixAsync(
        [FromQuery] ObterPixByChavePixRequest request) => await SendCommand(request);


    [HttpDelete("ChavePix")]
    [ProducesResponseType(typeof(DesabilitarChavePixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DesabilitarChavePixResponse>> DesabilitarChavePixAsync(
        [FromBody] DesabilitarChavePixRequest request) => await SendCommand(request);
}