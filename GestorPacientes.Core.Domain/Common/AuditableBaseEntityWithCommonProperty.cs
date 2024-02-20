using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Domain.Common
{
    public class AuditableBaseEntityWithCommonProperty : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string LastName { get; set; } = null!;
    }
}
