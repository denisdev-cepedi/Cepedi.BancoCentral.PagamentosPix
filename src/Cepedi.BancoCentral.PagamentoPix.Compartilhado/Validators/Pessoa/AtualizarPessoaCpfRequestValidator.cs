using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators.CommonRules;
using FluentValidation;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators
{
    public class AtualizarPessoaCpfRequestValidator : AbstractValidator<AtualizarPessoaCpfRequest>
    {
        public AtualizarPessoaCpfRequestValidator()
        {
               
            RuleFor(pessoa => pessoa.Cpf).CpfRules();

            RuleFor(pessoa => pessoa.NovoCpf).CpfRules();
            
        }
    }
}