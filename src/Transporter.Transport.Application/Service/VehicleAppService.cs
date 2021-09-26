using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using Transporter.Transport.Application.ViewModels;
using Transporter.Transport.Domain.Interfaces;
using Transporter.Transport.Domain.Models;

namespace Transporter.Transport.Application.Service
{
    public class VehicleAppService : IVehicleAppService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleAppService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public VehicleViewModel FindVehicleByLicensePlate(string licensePlate)
        {
            var vehicle = _vehicleRepository.FindBy(v => v.LicensePlate.Equals(licensePlate)).SingleOrDefault();
            return _mapper.Map<VehicleViewModel>(vehicle);
        }

        public async Task AddVehicle(VehicleViewModel vehicleViewModel)
        {
            vehicleViewModel.Id = vehicleViewModel.Id.Equals(Guid.Empty) ? Guid.NewGuid() : vehicleViewModel.Id;

            var vehicle = _mapper.Map<Vehicle>(vehicleViewModel);
            await _vehicleRepository.Add(vehicle);
            await _vehicleRepository.SaveChanges();
        }
    }
}
