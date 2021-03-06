
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentValidation.Results;
using MyFirstProject.Shared.Communication.Mediator;
using MyFirstProject.Shared.DomainObjects;
using MyFirstProject.Shared.Messages.Notifications;

namespace MyFirstProject.Shared.Messages
{
    public abstract class CommandHandler
    {
        private readonly IMediatorHandler _mediatorHandler;
        public CommandHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> ValidateEntity(Entity entity)
        {
            if (!entity.Invalid) return true;

            foreach (var error in entity.ValidationResult.Errors)
            {
                await AddNotification(error.ErrorCode, error.ErrorMessage);
            }

            return false;
        }

        public async Task<bool> ValidateCommand(Command command)
        {
            if (command.IsValid()) return true;

            await this.AddNotifications(command.ValidationResult.Errors);

            return false;
        }

        private async Task AddNotifications(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
                await AddNotification(error.ErrorCode, error.ErrorMessage);
        }

        public async Task AddNotification(string key, string message)
        {
            await _mediatorHandler.SendNotification(new DomainNotification(key, message));
        }
    }
}