using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Transporter.Core.Enums;

namespace Transporter.Transport.Application.ViewModels
{
    public class VehicleViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public VehicleType VehicleType { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Model { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Year { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CpfDriver { get; set; }

        public IEnumerable<TransportRecordViewModel> TransportRecordViewModels { get; set; }
    }
}
