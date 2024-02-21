using GestorPacientes.Core.Application.ViewModels.Doctors;
using GestorPacientes.Core.Application.ViewModels.LaboratoryTestResult;
using GestorPacientes.Core.Application.ViewModels.Patients;
using GestorPacientes.Core.Domain.Entities;
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

        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public PatientsViewModel? Patient { get; set; }
        public DoctorsViewModel? Doctor { get; set; }
        public ICollection<LaboratoryTestResultViewModel> Tests { get; } = null!;

    }
}
