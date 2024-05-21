using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using FluentValidation;
using FluentValidation.Validators;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators
{
    public class CriarPessoaRequestValidator : AbstractValidator<CriarPessoaRequest>
    {
        public CriarPessoaRequestValidator()
        {
            RuleFor(pessoa => pessoa.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MinimumLength(5).WithMessage("Pessoa deve ter pelo menos 5 caracteres");


        }
        
    }
}