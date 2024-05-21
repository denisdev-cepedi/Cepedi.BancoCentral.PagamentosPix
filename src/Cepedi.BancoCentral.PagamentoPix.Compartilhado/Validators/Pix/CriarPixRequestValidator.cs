
using System.Data;
using System.Security.Principal;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using FluentValidation;
using FluentValidation.Validators;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators;

public class CriarPixRequestValidator : AbstractValidator<CriarPixRequest>
{
    public CriarPixRequestValidator()
    {

        //Validação do codigo da instituição
        //Codigo minimo 1 e maximo 3
        //apenas numeros
        RuleFor(pix => pix.CodigoInstituicao)
            .NotEmpty().WithMessage("O Código da instituição é obrigatório.")
            .Length(1, 3).WithMessage("O Código da instituição deve ter no minimo 1 e no maximo 3 digitos.")
            .Matches(@"^\d+$").WithMessage("O Código da instituição deve conter apenas números.");
        ;
        //Validação da agência
        RuleFor(pix => pix.Agencia)
            .NotEmpty().WithMessage("A agência é obrigatória.")
            .Length(4, 5).WithMessage("A agência deve ter no minimo 4 e no maximo 5 digitos.")
            .Matches(@"^\d+$").WithMessage("A agência deve conter apenas números: Art.2 do Inciso IVº ISO 13.616 ");

        //Validação da conta 

        RuleFor(pix => pix.Conta)
            .NotEmpty().WithMessage("A conta é obrigatória.")
            .Length(5, 9).WithMessage("A conta deve ter no minimo 9 digitos sem o diito verificador");
        
        //calidação do campo do tipo pix
        RuleFor(request => request.TipoPix).NotEmpty().WithMessage("O campo do tipo de pix é obrigatório.");
        //Validação do chave pix
        RuleFor(request => request.ChavePix)
                .NotEmpty().WithMessage("Chave Pix é obrigatória.")
                .DependentRules(() =>
                {
                    //aleatória
                    When(request => request.TipoPix == "4", () =>
                    {
                        RuleFor(request => request.ChavePix)
                            .Matches("^[a-zA-Z0-9]{32}$").WithMessage("Chave Pix aleatória deve ter 32.");
                    });
                    //email
                    When(request => request.TipoPix == "2", () =>
                    {
                        RuleFor(request => request.ChavePix)
                            .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("Chave Pix do tipo email deve ser um email válido.");
                    });
                    //tcelular
                    When(request => request.TipoPix == "3", () =>
                    {
                        RuleFor(request => request.ChavePix)
                        .Matches(@"^\+\d{1,3}\d{1,14}$").WithMessage("Chave Pix do tipo telefone deve ser um número de telefone válido com código do país.");
                    });
                    //cpf
                    When(request => request.TipoPix == "1", () =>
                    {
                    RuleFor(request => request.ChavePix)
                        .Matches(@"^\d{11}$").WithMessage("Chave Pix do tipo CPF deve ter 11 dígitos numéricos.")
                        .Must(ValidarCpf).WithMessage("Chave Pix do tipo CPF deve ser um CPF válido.");
                    });

                });
    }
}

