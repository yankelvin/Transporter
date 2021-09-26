using System;
using System.ComponentModel.DataAnnotations;

namespace Transporter.Administration.Application.ViewModels
{
    public class UserViewModel : PersonViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Password { get; set; }

        public Guid PersonId { get; set; }
    }
}
