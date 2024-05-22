using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cepedi.BancoCentral.PagamentoPix.Api.Controllers
{
    
    [ApiController]
    [Route("[controller]/v1/Pessoas")]
    public class PessoaController: BaseController
    {
        private readonly ILogger<PessoaController> _logger;
        private readonly IMediator _mediator;

        public PessoaController(ILogger<PessoaController> logger, IMediator mediator)
            : base(mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        
    [HttpPost]
    [ProducesResponseType(typeof(CriarPessoaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarPessoaResponse>> CriarPessoaAsync(
        [FromBody] CriarPessoaRequest request) => await SendCommand(request);

    [HttpPut("Nome")]
    [ProducesResponseType(typeof(AtualizarPessoaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarPessoaResponse>> AtualizarPessoaAsync(
        [FromBody] AtualizarPessoaNomeRequest request) => await SendCommand(request);
    
    [HttpPut("Cpf")]
    [ProducesResponseType(typeof(AtualizarPessoaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarPessoaResponse>> AtualizarPessoaAsync(
        [FromBody] AtualizarPessoaCpfRequest request) => await SendCommand(request);

    
    [HttpGet]
    [OutputCache(Duration = 300)]
    [ProducesResponseType(typeof(ObterPessoaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<List<ObterPessoaResponse>>> ObterPessoasAsync(
        [FromQuery] ObterListPessoasRequest request
    ) 
        => await SendCommand(request);

    [HttpGet("Cpf")]
    [ProducesResponseType(typeof(ObterPessoaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<ObterPessoaResponse>> ObterPessoaAsync([FromBody] ObterPessoaRequest request) 
        => await SendCommand(request);
}
}