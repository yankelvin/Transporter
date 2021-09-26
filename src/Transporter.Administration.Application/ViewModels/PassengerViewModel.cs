using System;
using System.ComponentModel.DataAnnotations;

namespace Transporter.Administration.Application.ViewModels
{
    public class PassengerViewModel : PersonViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string City { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Uf { get; set; }

        public Guid PersonId { get; set; }
    }
}
