using System.Threading.Tasks;
using Transporter.Transport.Application.ViewModels;

namespace Transporter.Transport.Application.Service
{
    public interface IVehicleAppService
    {
        VehicleViewModel FindVehicleByLicensePlate(string licensePlate);
        Task AddVehicle(VehicleViewModel vehicleViewModel);
    }
}
