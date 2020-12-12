using Desafio.Domain.Models;
using Desafio.Repository.Interfaces;
using Desafio.Repository.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace Desafio.Repository.Services
{
    public class BaseService
    {
          private readonly INotificador _notificador;
        protected BaseService(INotificador notificador)
        {

            _notificador = notificador;
        }
        protected void Notificar(string message)
        {
            _notificador.Handle(new Notificacao(message));

        }
        protected bool ExecutarValidacao<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);
            if (validator.IsValid)
                return true;
            Notificar(validator.ToString());
            return false;
        }

        protected void Notificar(ValidationResult validation)
        {
           foreach(var erros in validation.Errors)
            {
                Notificar(erros.ErrorMessage);
            }

        }
    }
}