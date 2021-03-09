
using System.Threading.Tasks;
using MyFirstProject.Shared.Messages;
using MyFirstProject.Shared.Messages.Notifications;

namespace MyFirstProject.Shared.Communication.Mediator{
    public interface IMediatorHandler
    {
        // COMANDO CQRS
        Task<bool> SendCommand<T>(T comando) where T : Command;
        // EXCECOES/NOTIFICACOES PARA O USUARIO
        Task SendNotification<T>(T notificacao) where T : DomainNotification;
    }
}