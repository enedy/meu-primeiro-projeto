using MyFirstProject.Domain.ValueObjects;
using MyFirstProject.Shared.DomainObjects;

namespace MyFirstProject.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        protected User() { }
        public User(string name, string password, Email email, Document document, bool status)
        {
            Name = name;
            Password = password;
            Email = email;
            Document = document;
            Status = status;

            Validate(this, new UserValidator());
        }

        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public bool Status { get; private set; }
        public string Password { get; private set; }

        public void ChangeStatus(bool status)
        {
            Status = status;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}