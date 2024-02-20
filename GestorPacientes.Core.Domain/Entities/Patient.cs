using GestorPacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Patient : AuditableBaseEntityWithCommonProperty
    {
        public string Phone { get; set; } = null!;
        public string Direction { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? IsSmoker { get; set; }
        public string? IsAllergy { get; set; }
        public string? Photo { get; set; } 

        // Navigation Property 
        public ICollection<MedicalAppointment> Appointments { get; set; } = null!;
        public ICollection<LaboratoryTestResult> Tests { get; } = null!;

    }
}
