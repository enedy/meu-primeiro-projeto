using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using FluentValidation.Results;

namespace MyFirstProject.Shared.DomainObjects
{
    public abstract class Validation
    {
        [NotMapped]
        public bool Valid { get; private set; }
        [NotMapped]
        public bool Invalid => !Valid;
        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}