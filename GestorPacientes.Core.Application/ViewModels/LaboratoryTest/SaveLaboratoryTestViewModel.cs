using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.LaboratoryTest
{
    public class SaveLaboratoryTestViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter a name!!")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

    }
}
