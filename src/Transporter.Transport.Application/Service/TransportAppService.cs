using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transporter.Core.Enums;
using Transporter.Transport.Application.ViewModels;
using Transporter.Transport.Domain.Interfaces;
using Transporter.Transport.Domain.Models;

namespace Transporter.Transport.Application.Service
{
    public class TransportAppService : ITransportAppService
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ITransportRecordRepository _transportRecordRepository;

        public TransportAppService(IMapper mapper, IVehicleRepository vehicleRepository, ITransportRecordRepository transportRecordRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _transportRecordRepository = transportRecordRepository;
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

        public async Task AddTransportRecord(TransportRecordViewModel transportRecordViewModel)
        {
            transportRecordViewModel.Id = transportRecordViewModel.Id.Equals(Guid.Empty) ? Guid.NewGuid() : transportRecordViewModel.Id;
            transportRecordViewModel.Price = transportRecordViewModel.Kilometers * (decimal)0.4;

            var transportRecord = _mapper.Map<TransportRecord>(transportRecordViewModel);
            await _transportRecordRepository.Add(transportRecord);
            await _transportRecordRepository.SaveChanges();
        }

        public ReportViewModel MakeReport(DateTime dateInit, DateTime dateEnd)
        {
            var transports = _transportRecordRepository.FindByWithIncludes(p => p.TransportDate >= dateInit && p.TransportDate <= dateEnd, "Vehicle");

            var cars = transports.Where(p => p.Vehicle.VehicleType.Equals(VehicleType.Car));
            var bus = transports.Where(p => p.Vehicle.VehicleType.Equals(VehicleType.Bus));
            var vans = transports.Where(p => p.Vehicle.VehicleType.Equals(VehicleType.Van));

            return new ReportViewModel
            {
                Transports = _mapper.Map<List<TransportRecordViewModel>>(transports.ToList()),
                QuantityCars = cars.Count(),
                TotalValueCars = cars.Sum(p => p.Price),
                QuantityBus = bus.Count(),
                TotalValueBus = bus.Sum(p => p.Price),
                QuantityVans = vans.Count(),
                TotalValueVans = vans.Sum(p => p.Price),
            };
        }
    }
}
