using System;
using System.Collections.Generic;
using Transporter.Core.DomainObjects;
using Transporter.Core.Enums;

namespace Transporter.Transport.Domain.Models
{
    public class Vehicle : Entity
    {
        public VehicleType VehicleType { get; private set; }
        public string LicensePlate { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public int Capacity { get; private set; }
        public string CpfDriver { get; private set; }

        public virtual ICollection<TransportRecord> TransportRecords { get; private set; }

        protected Vehicle() { }

        public Vehicle(Guid id, VehicleType vehicleType, string licensePlate, string brand, string model,
                       int year, int capacity, string cpfDriver)
        {
            Id = id;
            VehicleType = vehicleType;
            LicensePlate = licensePlate;
            Brand = brand;
            Model = model;
            Year = year;
            Capacity = capacity;
            CpfDriver = cpfDriver;
        }
    }
}
