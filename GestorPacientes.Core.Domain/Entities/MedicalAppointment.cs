using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Domain.Entities
{
    public class MedicalAppointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour {  get; set; }
        public string Cause { get; set; } = null!;
        public string State { get; set; } = null!;

        // Navigation Property 
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public ICollection<LaboratoryTestResult> Tests { get; } = null!;

    }
}
