using Desafio.Domain.Models;
using FluentValidation;

namespace Desafio.Repository.Validation
{
    public class PatientValidation: AbstractValidator<Patient>
    {
        public PatientValidation()
        {
             RuleFor(f => f.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2,100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

             
                RuleFor(f => f.Cpf.Length).Equal(DocumentValidation.TamanhoCpf)
                .WithMessage("O campo CPF precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

                RuleFor(f=>f.Cpf)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.");

                RuleFor(f=>f.BirthDate)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.");

                RuleFor(f=>f.BirthDate)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.");

        }
    }
}
