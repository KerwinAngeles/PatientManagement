using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Domain.Entities
{
    public class LaboratoryTestResult
    {
        public int Id { get; set; }
        public string State { get; set; } = null!;
        public string? Result { get; set; }

        // Navigation Property 
        public int IdLaboratoryTest { get; set; }
        public int IdMedicalAppointment { get; set; }
        public int IdPatient { get; set; }
        public Patient? Patient { get; set; }
        public LaboratoryTest? Laboratory { get; set; }
        public MedicalAppointment? MedicalAppointment { get; set; }

    }
}
