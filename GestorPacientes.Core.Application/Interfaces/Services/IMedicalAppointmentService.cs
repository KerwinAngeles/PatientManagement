using GestorPacientes.Core.Application.ViewModels.MedicalAppointment;
using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IMedicalAppointmentService : IGenericService<SaveMedicalAppointmentViewModel, MedicalAppointmentViewModel, MedicalAppointment>
    {
        Task DeleteWithLabResult(int id);
        Task<List<MedicalAppointmentViewModel>> GetAllAppointmetWithPatientAndDoctor();
    }
}
