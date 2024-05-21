using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators.CommonRules;
using FluentValidation;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators.Pessoa
{
    public class ObterPessoaRequestValidator: AbstractValidator<ObterPessoaRequest>
    {
        public ObterPessoaRequestValidator()
        {      
            RuleFor(pessoa => pessoa.Cpf).CpfRules();
        }
    }
}