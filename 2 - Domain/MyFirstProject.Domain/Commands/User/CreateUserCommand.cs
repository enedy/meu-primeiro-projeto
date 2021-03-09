using FluentValidation;
using MyFirstProject.Domain.Enums;
using MyFirstProject.Shared.Messages;

namespace MyFirstProject.Domain.Commands
{
    public class CreateUserCommand : Command
    {
        public string Name { get; private set; }
        public string EmailAdress { get; private set; }
        public string DocumentNumber { get; private set; }
        public EDocumentType DocumentType { get; private set; }
        public bool Status { get; private set; }
        public string Password { get; private set; }

        public CreateUserCommand(string name, string emailAdress, string documentNumber,
        EDocumentType documentType, bool status, string password)
        {
            Name = name;
            EmailAdress = emailAdress;
            DocumentNumber = documentNumber;
            DocumentType = documentType;
            Status = status;
            Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateUserCommandValidation().Validate(instance: this);
            return ValidationResult.IsValid;
        }
    }

    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("O nome não foi informado");

            RuleFor(c => c.EmailAdress)
                .NotEmpty()
                .WithMessage("O e-mail não foi informado");

            RuleFor(c => c.DocumentNumber)
                .NotEmpty()
                .WithMessage("O número do documento não foi informado");

            RuleFor(c => c.Password)
                .NotEmpty()
                .WithMessage("O password não foi informado");
        }
    }
}