using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyFirstProject.Data.Contexts;
using MyFirstProject.Data.Repository;
using MyFirstProject.Domain.Commands;
using MyFirstProject.Domain.Queries;
using MyFirstProject.Domain.Repository;
using MyFirstProject.Shared.Communication.Mediator;
using MyFirstProject.Shared.Messages.Notifications;

namespace MyFirstProject.Infra.IoC
{
    public static class DependencyResolver
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Comandos
            services.AddScoped<IRequestHandler<CreateUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserNameCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, bool>, UserCommandHandler>();

            // Repository
            services.AddScoped<IUserRepository, UserRepository>();

            // Queries
            services.AddScoped<IUserQueries, UserQueries>();

            // DbContext
            services.AddScoped<MyFirstProjectContext>();
        }
    }
}