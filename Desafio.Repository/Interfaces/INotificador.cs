using System.Collections.Generic;
using Desafio.Repository.Notifications;

namespace Desafio.Repository.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacoes);
    }
}