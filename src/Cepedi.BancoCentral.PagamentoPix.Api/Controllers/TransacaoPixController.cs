using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.PagamentoPix.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransacaoPixController : BaseController
{
    private readonly ILogger<TransacaoPixController> _logger;
    private readonly IMediator _mediator;

    public TransacaoPixController(
        ILogger<TransacaoPixController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("{idTransacaoPix}")]
    [ProducesResponseType(typeof(ObterTransacaoPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<ObterTransacaoPixResponse>> ObterTransacaoPixAsync([FromRoute] int idTransacaoPix)
        => await SendCommand(new ObterTransacaoPixRequest(idTransacaoPix));

    [HttpGet]
    [ProducesResponseType(typeof(ObterListTransacoesPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<ObterListTransacoesPixResponse>> ObterTransacoesPixAsync()
    => await SendCommand(new ObterListTransacoesPixRequest());

    [HttpPost]
    [ProducesResponseType(typeof(CriarTransacaoPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarTransacaoPixResponse>> CriarTransacaoAsync(
        [FromBody] CriarTransacaoPixRequest request) => await SendCommand(request);

    /*
    [HttpPut]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<bool>> AtualizarTransacaoAsync(
        [FromBody] TransacaoPixEntity transacao)
    {
        var success = await _transacaoService.AtualizarTransacaoAsync(transacao);
        if (!success)
        {
            return BadRequest();
        }
        return Ok(success);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<bool>> DeletarTransacaoAsync(int id)
    {
        var success = await _transacaoService.DeletarTransacaoAsync(id);
        if (!success)
        {
            return BadRequest();
        }
        return Ok(success);
    }*/
}

