using GestorPacientes.Core.Application.ViewModels.Doctors;
using GestorPacientes.Core.Application.ViewModels.LaboratoryTest;
using GestorPacientes.Core.Application.ViewModels.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.LaboratoryTestResult
{
    public class SaveLaboratoryTestResultViewModel
    {
        public int Id { get; set; }
        public string State { get; set; } = "Pending";

        [Required(ErrorMessage = "You must enter a Report!!")]
        [DataType(DataType.Text)]
        public string Result {  get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "You must select a laboratory test!!")]
        public int LaboratoryTestId { get; set; }
        public List<int>? LaboratoryTests { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You must select a patient!!")]
        public int PatientId { get; set; }
        public List<int>? Patients { get; set; }
        public int MedicalAppointmentId { get; set; }
       
    }
}
