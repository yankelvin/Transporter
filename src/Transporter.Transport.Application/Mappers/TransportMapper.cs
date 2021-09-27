using AutoMapper;
using Transporter.Transport.Application.ViewModels;
using Transporter.Transport.Domain.Models;

namespace Transporter.Transport.Application.Mappers
{
    public class TransportMapper : Profile
    {
        public TransportMapper()
        {
            CreateMap<Vehicle, VehicleViewModel>();
            CreateMap<VehicleViewModel, Vehicle>()
                .ConstructUsing(p => new Vehicle(p.Id, p.VehicleType, p.LicensePlate, p.Brand, p.Model, p.Year, p.Capacity, p.CpfDriver));

            CreateMap<TransportRecord, TransportRecordViewModel>();
            CreateMap<TransportRecordViewModel, TransportRecord>()
                .ConstructUsing(p => new TransportRecord(p.Id, p.LicensePlate, p.CpfPassenger, p.TransportDate, p.Kilometers, p.Price, p.VehicleId));
        }
    }
}
