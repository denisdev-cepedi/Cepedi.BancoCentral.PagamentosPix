using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators.CommonRules;
using FluentValidation;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators
{
    public class AtualizarPessoaNomeRequestValidator : AbstractValidator<AtualizarPessoaNomeRequest>
    {
        public AtualizarPessoaNomeRequestValidator()
        {
            
            RuleFor(pessoa => pessoa.Nome).NomeRules();
               
            RuleFor(pessoa => pessoa.Cpf).CpfRules();
            
        }
    }
}