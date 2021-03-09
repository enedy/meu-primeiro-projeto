using System;
using FluentValidation;
using MyFirstProject.Shared.Messages;

namespace MyFirstProject.Domain.Commands
{
    public class DeleteUserCommand : Command
    {
        public Guid Id { get; private set; }

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteUserCommandValidation().Validate(instance: this);
            return ValidationResult.IsValid;
        }
    }

    public class DeleteUserCommandValidation : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O id não foi informado");
        }
    }
}