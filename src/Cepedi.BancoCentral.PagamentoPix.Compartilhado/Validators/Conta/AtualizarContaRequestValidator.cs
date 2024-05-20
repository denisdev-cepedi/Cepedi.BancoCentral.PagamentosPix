using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators
{
    public class AtualizarContaRequestValidator : AbstractValidator<AtualizarContaRequest>
    {
        public AtualizarContaRequestValidator()
        {
            
            RuleFor(request => request.IdConta)
            .NotNull().WithMessage("IdConta não pode ser nulo.");

        RuleFor(request => request.IdPessoa)
            .NotNull().WithMessage("IdPessoa não pode ser nulo.");

        RuleFor(request => request.Numero)
            .NotEmpty().WithMessage("Número da instituição é obrigatório.");

        RuleFor(request => request.Agencia)
            .NotEmpty().WithMessage("Agência é obrigatória.")
            .Matches(@"^\d+$").WithMessage("A agência deve ser em formato numérico.");

        RuleFor(request => request.Conta)
            .NotEmpty().WithMessage("Conta é obrigatória.")
            .Matches(@"^\d+$").WithMessage("A conta deve ser em formato numérico.");
        }
    }
}