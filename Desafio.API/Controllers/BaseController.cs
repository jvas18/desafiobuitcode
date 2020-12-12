using Desafio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    public class BaseController :ControllerBase
    {
         private readonly INotificador _notificador;
        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}