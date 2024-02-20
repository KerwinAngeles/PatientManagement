using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.Patients
{
    public class PatientsViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Direction { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? IsSmoker { get; set; }
        public string? IsAllergy { get; set; }
        public string? Photo { get; set; }
    }
}
