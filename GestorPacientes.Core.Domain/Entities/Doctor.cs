using GestorPacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Doctor : AuditableBaseEntityWithCommonProperty
    {
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string? Photo { get; set; }

        // Navigation Property 
        public ICollection<MedicalAppointment> Appointments { get; set; } = null!;

    }
}
