using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators
{
    public class AtualizarPessoaRequestValidator : AbstractValidator<AtualizarPessoaRequest>
    {
        public AtualizarPessoaRequestValidator()
        {
            
            RuleFor(pessoa => pessoa.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MinimumLength(5).WithMessage("Pessoa deve ter pelo menos 5 caracteres");

            RuleFor(pessoa => pessoa.Cpf)
                .Matches("^[0-9]+$").WithMessage("Cpf deve conter apenas números");
                
            RuleFor(pessoa => pessoa.Cpf)
                .NotEmpty().WithMessage("Cpf é obrigatório")
                .Length(11).WithMessage("Cpf deve ter 11 caracteres");

            RuleFor(pessoa => pessoa.NovoCpf)
            .Must(Utils.Utils.ValidarCpf).WithMessage("Cpf inválido");

            RuleFor(pessoa => pessoa.NovoCpf)
                .Matches("^[0-9]+$").WithMessage("Cpf deve conter apenas números");
                
            RuleFor(pessoa => pessoa.NovoCpf)
                .NotEmpty().WithMessage("Cpf é obrigatório")
                .Length(11).WithMessage("Cpf deve ter 11 caracteres");

            RuleFor(pessoa => pessoa.NovoCpf)
            .Must(Utils.Utils.ValidarCpf).WithMessage("Cpf inválido");
        }
    }
}