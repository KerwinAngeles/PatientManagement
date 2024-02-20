using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.Patients
{
    public class SavePatientsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter a name!!")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "You must enter a last name!!")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a phone!!")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a direction!!")]
        [DataType(DataType.Text)]
        public string Direction { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a identification!!")]
        [DataType(DataType.Text)]
        public string Identification { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a birthdate!!")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "You must enter if you are smoker!!")]
        [DataType(DataType.Text)]
        public string? IsSmoker { get; set; }

        [Required(ErrorMessage = "You must enter if you are allergy!!")]
        [DataType(DataType.Text)]
        public string? IsAllergy { get; set; }
        public string? Photo { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }
    }
}
