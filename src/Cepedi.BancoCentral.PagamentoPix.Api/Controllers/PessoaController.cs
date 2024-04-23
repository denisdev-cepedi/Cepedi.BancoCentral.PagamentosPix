using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Excecoes;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.PagamentoPix.Api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
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

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarPessoaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarPessoaResponse>> AtualizarPessoaAsync(
        [FromBody] AtualizarPessoaRequest request) => await SendCommand(request);

    
    [HttpGet]
    [ProducesResponseType(typeof(ObterListPessoasResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<ObterListPessoasResponse>> ObterPessoasAsync() 
        => await SendCommand(new ObterListPessoasRequest());

    [HttpGet("{idPessoa}")]
    [ProducesResponseType(typeof(ObterPessoaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<ObterPessoaResponse>> ObterPessoaAsync([FromRoute] int idPessoa) 
        => await SendCommand(new ObterPessoaRequest(idPessoa));
   
    }
   
}