using System;
using Transporter.Core.DomainObjects;

namespace Transporter.Administration.Domain.Models
{
    public class Driver : Entity
    {
        public Guid PersonId { get; private set; }
        public virtual Person Person { get; private set; }

        protected Driver() { }

        public Driver(Guid id, Person person)
        {
            Id = id;
            Person = person;
        }
    }
}
