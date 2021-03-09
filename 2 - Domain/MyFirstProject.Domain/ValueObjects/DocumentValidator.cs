using FluentValidation;
using MyFirstProject.Domain.Enums;

namespace MyFirstProject.Domain.ValueObjects
{
    public class DocumentValidator : AbstractValidator<Document>
    {
        public DocumentValidator()
        {
            When(document => document.Type == EDocumentType.CNPJ, () =>
            {
                RuleFor(document => document.Number.Length).Equal(14)
                .WithMessage("O CNPJ deve conter 14 dígitos");
            });

            When(document => document.Type == EDocumentType.CPF, () =>
            {
                RuleFor(document => document.Number.Length).Equal(11)
                .WithMessage("O CPF deve conter 11 dígitos");
            });
        }
    }
}