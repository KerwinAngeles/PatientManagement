using GestorPacientes.Core.Application.ViewModels.Patients;
using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IPatientService : IGenericService<SavePatientsViewModel, PatientsViewModel, Patient>
    {

    }
}
