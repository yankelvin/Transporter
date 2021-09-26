using System;
using Transporter.Core.DomainObjects;

namespace Transporter.Administration.Domain.Models
{
    public class Passenger : Entity
    {
        public string City { get; private set; }
        public string Uf { get; private set; }

        public Guid PersonId { get; private set; }
        public virtual Person Person { get; private set; }

        protected Passenger() { }

        public Passenger(Guid id, string city, string uf, Person person)
        {
            Id = id;
            City = city;
            Uf = uf;
            Person = person;
        }
    }
}
