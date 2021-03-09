
using System.Threading.Tasks;
using MediatR;
using MyFirstProject.Shared.Messages;
using MyFirstProject.Shared.Messages.Notifications;

namespace MyFirstProject.Shared.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> SendCommand<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task SendNotification<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }
    }
}