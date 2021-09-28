using System.Collections.Generic;

namespace Transporter.Transport.Application.ViewModels
{
    public class ReportViewModel
    {
        public List<TransportRecordViewModel> Transports { get; set; }
        public int QuantityCars { get; set; }
        public decimal TotalValueCars { get; set; }

        public int QuantityBus { get; set; }
        public decimal TotalValueBus { get; set; }

        public int QuantityVans { get; set; }
        public decimal TotalValueVans { get; set; }
    }
}
