using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Utils;
using FluentValidation;

public static class PixRules


{
    public static IRuleBuilderOptions<T, string> TipoPixRules<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.NotEmpty().WithMessage("O campo do tipo de pix é obrigatório.");

    }
    public static IRuleBuilderOptions<T, string> CodigoInstituicaoRules<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("O Código da instituição é obrigatório.")
            .Length(1, 3).WithMessage("O Código da instituição deve ter no mínimo 1 e no máximo 3 dígitos.")
            .Matches(@"^\d+$").WithMessage("O Código da instituição deve conter apenas números.");
    }

    public static IRuleBuilderOptions<T, string> AgenciaRules<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("A agência é obrigatória.")
            .Length(4, 5).WithMessage("A agência deve ter no mínimo 4 e no máximo 5 dígitos.")
            .Matches(@"^\d+$").WithMessage("A agência deve conter apenas números: Art.2 do Inciso IVº ISO 13.616.");
    }

    public static IRuleBuilderOptions<T, string> ContaRules<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("A conta é obrigatória.")
            .Length(5, 9).WithMessage("A conta deve ter no mínimo 5 e no máximo 9 dígitos sem o dígito verificador.");
    }
    public static IRuleBuilderOptions<T, string> ChavePixNotEmpty<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Chave Pix é obrigatória.");
    }

    public static IRuleBuilderOptions<T, string> ChavePixAleatoria<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches("^[a-zA-Z0-9]{32}$").WithMessage("Chave Pix aleatória deve ter 32 caracteres.");
    }

    public static IRuleBuilderOptions<T, string> ChavePixEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
            .WithMessage("Chave Pix do tipo email deve ser um email válido.");
    }

    public static IRuleBuilderOptions<T, string> ChavePixTelefone<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
       return ruleBuilder
            .Matches(@"^\+\d{1,3}\d{1,14}$").WithMessage("Chave Pix do tipo telefone deve conter apenas números e um código de país válido.")
            .Length(10, 15).WithMessage("Chave Pix do tipo telefone deve ter entre 10 e 15 caracteres.");
    }
    public static IRuleBuilderOptions<T, string> ChavePixCpf<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches(@"^\d{11}$").WithMessage("Chave Pix do tipo CPF deve ter 11 dígitos numéricos.")
            .Must(Utils.ValidarCpf).WithMessage("Chave Pix do tipo CPF deve ser um CPF válido.");
    }
}
