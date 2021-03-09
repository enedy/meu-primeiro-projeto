using FluentValidation;
using MyFirstProject.Domain.Enums;
using MyFirstProject.Shared.Messages;

namespace MyFirstProject.Domain.Commands
{
    public class UpdateUserNameCommand : Command
    {
        public string Name { get; private set; }
        public string EmailAdress { get; private set; }
        public string Password { get; private set; }

        public UpdateUserNameCommand(string name, string emailAdress, string password)
        {
            Name = name;
            EmailAdress = emailAdress;
            Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserNameCommandValidation().Validate(instance: this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateUserNameCommandValidation : AbstractValidator<UpdateUserNameCommand>
    {
        public UpdateUserNameCommandValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("O nome não foi informado");

            RuleFor(c => c.EmailAdress)
                .NotEmpty()
                .WithMessage("O e-mail não foi informado");

            RuleFor(c => c.Password)
                .NotEmpty()
                .WithMessage("O password não foi informado");
        }
    }
}