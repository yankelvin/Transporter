using System;
using Transporter.Core.DomainObjects;

namespace Transporter.Administration.Domain.Models
{
    public class User : Entity
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public Guid PersonId { get; private set; }
        public virtual Person Person { get; private set; }

        protected User() { }

        public User(Guid id, string userName, string password, Person person)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Person = person;
        }
    }
}
