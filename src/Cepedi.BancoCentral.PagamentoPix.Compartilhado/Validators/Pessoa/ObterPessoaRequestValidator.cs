using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators.Pessoa
{
    public class ObterPessoaRequestValidator: AbstractValidator<ObterPessoaRequest>
    {
        public ObterPessoaRequestValidator()
        {
            RuleFor(request => request.Cpf).NotEmpty()
            .WithMessage("Cpf deve ser informado")
            .Length(11).WithMessage("Cpf deve ter 11 caracteres")
            .Matches("^[0-9]+$").WithMessage("Cpf deve conter apenas números")
            .Must(Utils.Utils.ValidarCpf).WithMessage("Cpf inválido");
        }
    }
}