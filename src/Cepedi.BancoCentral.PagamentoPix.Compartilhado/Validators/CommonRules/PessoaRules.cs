using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators.CommonRules
{
    public static class PessoaRules
    {
        public static IRuleBuilderOptions<T, string> NomeRules<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return  ruleBuilder
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MinimumLength(5).WithMessage("Pessoa deve ter pelo menos 5 caracteres");
        }
        public static IRuleBuilderOptions<T, string> CpfRules<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return  ruleBuilder
                .NotEmpty().WithMessage("Cpf é obrigatório")
                .Length(11).WithMessage("Cpf deve ter 11 caracteres")
                .Matches("^[0-9]+$").WithMessage("Cpf deve conter apenas números")
                .Must(Utils.Utils.ValidarCpf).WithMessage("Cpf inválido");
        }
    }
}