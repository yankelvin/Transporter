using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using Transporter.Administration.Application.ViewModels;
using Transporter.Administration.Domain.Interfaces;
using Transporter.Administration.Domain.Models;

namespace Transporter.Administration.Application.Service
{
    public class UserAppService : IUserAppService
    {

        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IDriverRepository _driverRepository;

        public UserAppService(IUserRepository userRepository, IMapper mapper, IPassengerRepository passengerRepository,
                              IDriverRepository driverRepository, IPersonRepository personRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passengerRepository = passengerRepository;
            _driverRepository = driverRepository;
            _personRepository = personRepository;
        }

        public UserViewModel FindUserByUserName(string userName)
        {
            var user = _userRepository.FindBy(u => u.UserName.Equals(userName)).SingleOrDefault();
            return _mapper.Map<UserViewModel>(user);
        }

        public PersonViewModel FindPersonByCpf(string cpf)
        {
            var person = _personRepository.FindBy(u => u.CPF.Equals(cpf)).SingleOrDefault();
            return _mapper.Map<PersonViewModel>(person);
        }

        public DriverViewModel FindDriverByPersonId(Guid personId)
        {
            var driver = _driverRepository.FindBy(p => p.PersonId.Equals(personId)).SingleOrDefault();
            return _mapper.Map<DriverViewModel>(driver);
        }

        public PassengerViewModel FindPassengerByPersonId(Guid personId)
        {
            var passenger = _passengerRepository.FindBy(p => p.PersonId.Equals(personId)).SingleOrDefault();
            return _mapper.Map<PassengerViewModel>(passenger);
        }

        public async Task AddUser(UserViewModel userViewModel)
        {
            userViewModel.Id = userViewModel.Id.Equals(Guid.Empty) ? Guid.NewGuid() : userViewModel.Id;

            var user = _mapper.Map<User>(userViewModel);
            await _userRepository.Add(user);
            await _userRepository.SaveChanges();
        }

        public async Task AddPassenger(PassengerViewModel userViewModel)
        {
            userViewModel.Id = userViewModel.Id.Equals(Guid.Empty) ? Guid.NewGuid() : userViewModel.Id;

            var passenger = _mapper.Map<Passenger>(userViewModel);
            await _passengerRepository.Add(passenger);
            await _passengerRepository.SaveChanges();
        }

        public async Task AddDriver(DriverViewModel userViewModel)
        {
            userViewModel.Id = userViewModel.Id.Equals(Guid.Empty) ? Guid.NewGuid() : userViewModel.Id;

            var driver = _mapper.Map<Driver>(userViewModel);
            await _driverRepository.Add(driver);
            await _driverRepository.SaveChanges();
        }
    }
}

