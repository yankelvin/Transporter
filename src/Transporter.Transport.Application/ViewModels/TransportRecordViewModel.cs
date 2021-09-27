using System;
using System.ComponentModel.DataAnnotations;

namespace Transporter.Transport.Application.ViewModels
{
    public class TransportRecordViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CpfPassenger { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime TransportDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Kilometers { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string LicensePlate { get; set; }

        public Guid VehicleId { get; set; }
        public VehicleViewModel VehicleViewModel { get; set; }
    }
}
