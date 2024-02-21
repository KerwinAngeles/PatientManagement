using GestorPacientes.Core.Application.ViewModels.MedicalAppointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.Doctors
{
    public class DoctorsViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string? Photo { get; set; }

        public ICollection<MedicalAppointmentViewModel> Appointments { get; set; } = null!;
    }
}
