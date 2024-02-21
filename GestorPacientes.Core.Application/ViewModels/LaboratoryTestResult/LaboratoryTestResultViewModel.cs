using GestorPacientes.Core.Application.ViewModels.LaboratoryTest;
using GestorPacientes.Core.Application.ViewModels.MedicalAppointment;
using GestorPacientes.Core.Application.ViewModels.Patients;
using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.LaboratoryTestResult
{
    public class LaboratoryTestResultViewModel
    {
        public int Id { get; set; }
        public string? LaboratoryTestName { get; set; }
        public string? PatientName { get; set; }
        public string? PatientLastName { get; set; }
        public string? PatientIdentification { get; set; }
        public string? State { get; set; }
        public string? Result {  get; set; }

        public int IdLaboratoryTest { get; set; }
        public int IdMedicalAppointment { get; set; }
        public int IdPatient { get; set; }
        public PatientsViewModel? Patient { get; set; }
        public LaboratoryTestViewModel? Laboratory { get; set; }
        public MedicalAppointmentViewModel? MedicalAppointment { get; set; }
    }
}
