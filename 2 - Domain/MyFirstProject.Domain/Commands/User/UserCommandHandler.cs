using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyFirstProject.Shared.Communication.Mediator;
using MyFirstProject.Domain.Entities;
using MyFirstProject.Domain.ValueObjects;
using MyFirstProject.Shared.Messages;
using MyFirstProject.Domain.Repository;

namespace MyFirstProject.Domain.Commands
{
    public class UserCommandHandler : CommandHandler, IRequestHandler<CreateUserCommand, bool>,
    IRequestHandler<UpdateUserNameCommand, bool>,
    IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IMediatorHandler mediatorHandler,
        IUserRepository userRepository) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _userRepository = userRepository;
        }

        // CancellationToken =  Propaga a notificação de que as operações devem ser canceladas.
        public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (!await ValidateCommand(command)) return false;

            // INSTANCIA O OBJETO
            var user = new User(
                name: command.Name,
                password: command.Password,
                email: new Email(command.EmailAdress),
                document: new Document(command.DocumentNumber, command.DocumentType), command.Status
                );

            // VALIDA O OBJETO
            if (!await ValidateEntity(user)) return false;

            // ADICIONA NO CONTEXTO
            _userRepository.CreateUserAsync(user);

            // COMITA
            return await _userRepository.UnitOfWork.Commit();
        }

        // CancellationToken =  Propaga a notificação de que as operações devem ser canceladas.
        public async Task<bool> Handle(UpdateUserNameCommand command, CancellationToken cancellationToken)
        {
            // CONSULTA O USUARIO
            var user = await _userRepository.GetUserAsync(command.EmailAdress, command.Password);
            user.ChangeName(command.Name);

            // ADICIONA NO CONTEXTO
            _userRepository.UpdateUserAsync(user);

            // COMITA
            return await _userRepository.UnitOfWork.Commit();
        }

        // CancellationToken =  Propaga a notificação de que as operações devem ser canceladas.
        public async Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            // ADICIONA NO CONTEXTO
            await _userRepository.DeleteUserAsync(command.Id);

            // COMITA
            return await _userRepository.UnitOfWork.Commit();
        }
    }
}