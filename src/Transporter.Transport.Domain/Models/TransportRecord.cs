using System;
using Transporter.Core.DomainObjects;

namespace Transporter.Transport.Domain.Models
{
    public class TransportRecord : Entity
    {
        public string LicensePlate { get; private set; }
        public string CpfPassenger { get; private set; }
        public DateTime TransportDate { get; private set; }
        public int Kilometers { get; private set; }
        public decimal Price { get; private set; }

        public Guid VehicleId { get; private set; }
        public virtual Vehicle Vehicle { get; private set; }

        protected TransportRecord() { }

        public TransportRecord(Guid id, string licensePlate, string cpfPassenger, DateTime transportDate,
                               int kilometers, decimal price, Guid vehicleId)
        {
            Id = id;
            LicensePlate = licensePlate;
            CpfPassenger = cpfPassenger;
            TransportDate = transportDate;
            Kilometers = kilometers;
            Price = price;
            VehicleId = vehicleId;
        }
    }
}
