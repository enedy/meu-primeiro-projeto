using System;

namespace MyFirstProject.Shared.DomainObjects
{
    public abstract class Entity : Validation
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}