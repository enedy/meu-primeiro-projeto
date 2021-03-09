using MyFirstProject.Shared.ValueObjects;

namespace MyFirstProject.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
            Validate(this, new EmailValidator());
        }

        public string Address { get; private set; }
    }
}