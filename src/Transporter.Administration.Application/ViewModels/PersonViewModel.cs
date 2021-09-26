using System;
using System.ComponentModel.DataAnnotations;

namespace Transporter.Administration.Application.ViewModels
{
    public class PersonViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Address { get; set; }
    }
}
