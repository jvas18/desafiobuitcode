using Desafio.Domain.Models;
using FluentValidation;

namespace Desafio.Repository.Validation
{
    public class DoctorValidation : AbstractValidator<Doctor>
    {
        public DoctorValidation()
        {
             RuleFor(f=>f.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2,100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

                RuleFor(f=>f.Crm)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.");

                RuleFor(f=>f.CrmUf)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.");
        }
    }
}