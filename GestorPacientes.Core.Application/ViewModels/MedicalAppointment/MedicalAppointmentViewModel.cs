using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.MedicalAppointment
{
    public class MedicalAppointmentViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string Cause { get; set; } = null!;
        public string State { get; set; } = null!;

        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }


    }
}
