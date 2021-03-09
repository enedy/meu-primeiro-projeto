using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Shared.Communication.Mediator;
using MyFirstProject.Shared.Messages.Notifications;

namespace MyFirstProject.Api.Extensions
{
    public abstract class MainApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHandler;
        protected MainApiController(INotificationHandler<DomainNotification> notifications,
                                 IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }
        
        protected bool CheckOperation()
        {
            return !_notifications.ExistsNotification();
        }

        protected IEnumerable<string> GetErrorMessages()
        {
            return _notifications.GetNotifications().Select(c => c.Value).ToList();
        }

        protected IActionResult CustomOk(object result = null, string message = null)
        {
            return Ok(new
            {
                Success = true,
                Data = result,
                Message = message
            });
        }

        protected IActionResult CustomNotFound(string message)
        {
            return NotFound(new
            {
                Success = false,
                Message = message
            });
        }

        protected IActionResult CustomResponseError()
        {
            return BadRequest(new
            {
                Success = false,
                Message = this.GetErrorMessages()
            });
        }
    }
}