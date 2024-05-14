using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado.Requests;
using FluentValidation;
using FluentValidation.Validators;

namespace Cepedi.BancoCentral.PagamentoPix.Compartilhado.Validators
{
    public class CriarPessoaRequestValidator : AbstractValidator<CriarPessoaRequest>
    {
        public CriarPessoaRequestValidator()
        {
            RuleFor(pessoa => pessoa.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MinimumLength(5).WithMessage("Pessoa deve ter pelo menos 5 caracteres");

            RuleFor(pessoa => pessoa.Cpf)
                .Matches("^[0-9]+$").WithMessage("Cpf deve conter apenas números");
                
            RuleFor(pessoa => pessoa.Cpf)
                .NotEmpty().WithMessage("Cpf é obrigatório")
                .Length(11).WithMessage("Cpf deve ter 11 caracteres");

            // RuleFor(pessoa => pessoa.Cpf)
            //     .Must(ValidarCpf).WithMessage("Cpf inválido");




        }
        
    }
    // private bool ValidarCpf(string cpf)
    // {
    //     int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
    //     int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
    //     string tempCpf;
    //     string digito;
    //     int soma;
    //     int resto;

    //     cpf = cpf.Trim().Replace(".", "").Replace("-", "");
    //     if (cpf.Length != 11)
    //     return false;

    //     tempCpf = cpf.Substring(0, 9);
    //     soma = 0;

    //     for(int i = 0; i < 9; i++)
    //         soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

    //     resto = soma % 11;
    //     if (resto < 2)
    //         resto = 0;
    //     else
    //     resto = 11 - resto;

    //     digito = resto.ToString();
    //     tempCpf = tempCpf + digito;
    //     soma = 0;

    //     for(int i = 0; i < 10; i++)
    //         soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

    //     resto = soma % 11;
    //     if (resto < 2)
    //         resto = 0;
    //     else
    //     resto = 11 - resto;

    //     digito = digito + resto.ToString();

    //     return cpf.EndsWith(digito);
    // }

}