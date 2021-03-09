using MyFirstProject.Domain.Enums;
using MyFirstProject.Shared.ValueObjects;

namespace MyFirstProject.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            Validate(this, new DocumentValidator());
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool ValidateDocument()
        {
            if (Type == EDocumentType.CNPJ && Number.Length == 14)
                return true;

            if (Type == EDocumentType.CPF && Number.Length == 11)
                return true;

            return false;
        }
    }
}