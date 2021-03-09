using FluentValidation;

namespace MyFirstProject.Domain.ValueObjects
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(email => email.Address)
            .NotEmpty()
            .WithMessage("E-Mail não pode ser nulo.")
            .EmailAddress()
            .WithMessage("E-Mail não é válido.");
        }
    }
}