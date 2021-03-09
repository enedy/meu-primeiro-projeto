using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Api.Extensions;
using MyFirstProject.Domain.Commands;
using MyFirstProject.Domain.Enums;
using MyFirstProject.Domain.Queries;
using MyFirstProject.Shared.Communication.Mediator;
using MyFirstProject.Shared.Messages.Notifications;

namespace MyFirstProject.Api.v1.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/user")]
    public class UserController : MainApiController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUserQueries _userQueries;
        public UserController(INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediatorHandler, IUserQueries userQueries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _userQueries = userQueries;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string emailAdress, string password)
        {
            var user = await _userQueries.GetUserAsync(emailAdress, password);
            if (user == null) return CustomNotFound("Usuário não encontrado.");

            return CustomOk(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(string name, string emailAdress, string password,
         string documentNumber, EDocumentType documentType, bool status)
        {
            var command = new CreateUserCommand(name, emailAdress, documentNumber, documentType,
            status, password);
            await _mediatorHandler.SendCommand(command);

            if (CheckOperation())
                return CustomOk(null, "Usuário criado com sucesso.");

            return CustomResponseError();
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(string name, string emailAdress, string password)
        {
            var command = new UpdateUserNameCommand(name, emailAdress, password);
            await _mediatorHandler.SendCommand(command);

            if (CheckOperation())
                return CustomOk(null, "Usuário alterado com sucesso.");

            return CustomResponseError();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand(id);
            await _mediatorHandler.SendCommand(command);

            if (CheckOperation())
                return CustomOk(null, "Usuário deletado com sucesso.");

            return CustomResponseError();
        }
    }
}