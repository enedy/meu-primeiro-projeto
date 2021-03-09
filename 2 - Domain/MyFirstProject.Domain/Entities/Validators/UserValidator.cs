using FluentValidation;

namespace MyFirstProject.Domain.Entities
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
            .NotEmpty()
            .WithMessage("O nome é obrigatório.");

            RuleFor(pwd => pwd.Password)
            .NotEmpty()
            .WithMessage("Password inválido.");
        }
    }
}