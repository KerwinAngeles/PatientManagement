using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.Doctors
{
    public class SaveDoctorsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter a name!!")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "You must enter a last name!!")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a email!!")]
        [DataType(DataType.Text)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a phone!!")]
        [DataType(DataType.Text)]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a identification!!")]
        [DataType(DataType.Text)]
        public string Identification { get; set; } = null!;
        public string? Photo { get; set; } 

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }
    }
}
