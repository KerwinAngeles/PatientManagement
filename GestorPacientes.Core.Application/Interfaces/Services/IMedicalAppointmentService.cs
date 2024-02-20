using GestorPacientes.Core.Application.ViewModels.MedicalAppointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IMedicalAppointmentService : IGenericService<SaveMedicalAppointmentViewModel, MedicalAppointmentViewModel>
    {
        Task DeleteWithLabResult(int id);
    }
}
