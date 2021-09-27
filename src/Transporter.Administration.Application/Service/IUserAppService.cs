using System;
using System.Threading.Tasks;
using Transporter.Administration.Application.ViewModels;

namespace Transporter.Administration.Application.Service
{
    public interface IUserAppService
    {
        UserViewModel FindUserByUserName(string userName);
        PersonViewModel FindPersonByCpf(string cpf);
        DriverViewModel FindDriverByPersonId(Guid personId);
        PassengerViewModel FindPassengerByPersonId(Guid personId);
        Task AddUser(UserViewModel userViewModel);
        Task AddPassenger(PassengerViewModel userViewModel);
        Task AddDriver(DriverViewModel userViewModel);
    }
}

