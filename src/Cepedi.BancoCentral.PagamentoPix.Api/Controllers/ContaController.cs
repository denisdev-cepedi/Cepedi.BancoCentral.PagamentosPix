﻿using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.PagamentoPix.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContaController : BaseController
{
    private readonly ILogger<ContaController> _logger;
    private readonly IMediator _mediator;

    public ContaController(
        ILogger<ContaController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }


    [HttpPost]
    [ProducesResponseType(typeof(CriarContaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarContaResponse>> CriarContaAsync(
        [FromBody] CriarContaRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarContaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarContaResponse>> AtualizarContaAsync(
        [FromBody] AtualizarContaRequest request) => await SendCommand(request);

    [HttpGet("{idPessoa}")]
    [ProducesResponseType(typeof(ObterListContaByPessoaIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<ObterListContaByPessoaIdResponse>> ObterContasAsync(
        [FromRoute] int idPessoa) => await SendCommand(new ObterListContaByPessoaIdRequest(idPessoa));

}
