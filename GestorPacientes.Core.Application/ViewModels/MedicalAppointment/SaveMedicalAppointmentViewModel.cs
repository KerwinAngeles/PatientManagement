using GestorPacientes.Core.Application.ViewModels.Doctors;
using GestorPacientes.Core.Application.ViewModels.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.MedicalAppointment
{
    public class SaveMedicalAppointmentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter a date!!")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "You must enter an hour!!")]
        [DataType(DataType.Time)]
        public TimeSpan Hour { get; set; }

        [Required(ErrorMessage = "You must enter a cause!!")]
        [DataType(DataType.Text)]
        public string Cause { get; set; } = null!;
        public string State { get; set; } = "Pending";

        [Range(1, int.MaxValue, ErrorMessage = "You must select a patient!!")]
        public int IdPatient { get; set; }
        public List<PatientsViewModel>? Patients { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You must select a doctor!!")]
        public int IdDoctor { get; set; }
        public List<DoctorsViewModel>? Doctors { get; set; }
    }
}
