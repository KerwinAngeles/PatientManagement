using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Navigation Property 
        public ICollection<User> Users { get; set; } = null!;
    }
}
