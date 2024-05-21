
using Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;
using FluentValidation;
using FluentValidation.Validators;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators;


public class ObterPixByChavePixRequestValidator : AbstractValidator<ObterPixByChavePixRequest>{


    public ObterPixByChavePixRequestValidator(){

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
     private bool ValidarCpf(string cpf)
    {
        // Adicione aqui a lógica de validação de CPF, incluindo os dígitos verificadores.
        // Este é um exemplo simplificado e você pode querer usar uma biblioteca ou lógica mais completa.
        if (cpf.Length != 11 || !long.TryParse(cpf, out _))
        {
            return false;
        }

        var cpfDigits = cpf.Select(d => int.Parse(d.ToString())).ToArray();

        int AddDigits(int[] digits, int[] multipliers)
        {
            return digits.Zip(multipliers, (d, m) => d * m).Sum();
        }

        bool ValidateDigit(int[] digits, int position)
        {
            int[] multipliers = position == 9 ? new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 } : new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = AddDigits(digits.Take(position).ToArray(), multipliers);
            int result = sum % 11;
            int verifier = result < 2 ? 0 : 11 - result;
            return verifier == digits[position];
        }

        return ValidateDigit(cpfDigits, 9) && ValidateDigit(cpfDigits, 10);
    }

}