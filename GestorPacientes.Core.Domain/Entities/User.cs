using GestorPacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Domain.Entities
{
    public class User : AuditableBaseEntityWithCommonProperty
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        // Navigation Property 
        public int IdRol {  get; set; }
        public Rol Rol { get; set; } = null!;
    }
}
