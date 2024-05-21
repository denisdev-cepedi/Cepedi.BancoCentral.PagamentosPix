using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators.CommonRules;
using FluentValidation;
using FluentValidation.Validators;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators
{
    public class CriarPessoaRequestValidator : AbstractValidator<CriarPessoaRequest>
    {
        
        public CriarPessoaRequestValidator()
        {
           
            RuleFor(pessoa => pessoa.Nome).NomeRules();
               
            RuleFor(pessoa => pessoa.Cpf).CpfRules();

        }
    }
}