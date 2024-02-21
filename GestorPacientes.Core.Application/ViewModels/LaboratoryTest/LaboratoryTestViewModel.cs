using GestorPacientes.Core.Application.ViewModels.LaboratoryTestResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.LaboratoryTest
{
    public class LaboratoryTestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<LaboratoryTestResultViewModel> Tests { get; } = null!;

    }
}
