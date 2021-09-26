using AutoMapper;
using Transporter.Administration.Application.ViewModels;
using Transporter.Administration.Domain.Models;

namespace Transporter.Administration.Application.Mappers
{
    public class AdministrationMapper : Profile
    {
        public AdministrationMapper()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>()
                .ConstructUsing(u => new User(u.Id, u.UserName, u.Password, new Person(u.PersonId, u.Name, u.BirthDate, u.CPF, u.Address)));

            CreateMap<Passenger, PassengerViewModel>();
            CreateMap<PassengerViewModel, Passenger>()
                .ConstructUsing(u => new Passenger(u.Id, u.City, u.Uf, new Person(u.PersonId, u.Name, u.BirthDate, u.CPF, u.Address)));

            CreateMap<Driver, DriverViewModel>();
            CreateMap<DriverViewModel, Driver>()
                .ConstructUsing(u => new Driver(u.Id, new Person(u.PersonId, u.Name, u.BirthDate, u.CPF, u.Address)));

            CreateMap<Person, PersonViewModel>();
            CreateMap<PersonViewModel, Person>()
                .ConstructUsing(u => new Person(u.Id, u.Name, u.BirthDate, u.CPF, u.Address));
        }
    }
}
