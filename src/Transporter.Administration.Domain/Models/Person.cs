using System;
using Transporter.Core.DomainObjects;

namespace Transporter.Administration.Domain.Models
{
    public class Person : Entity
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string CPF { get; private set; }
        public string Address { get; private set; }

        public virtual User User { get; private set; }
        public virtual Passenger Passenger { get; private set; }
        public virtual Driver Driver { get; private set; }

        protected Person() { }

        public Person(Guid id, string name, DateTime birthDate, string cPF, string address)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            CPF = cPF;
            Address = address;
        }
    }
}
