using GestorPacientes.Core.Application.Helpers;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application
{
    public static class ServicesRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region "Services"
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<ILaboratoryTestService, LaboratoryTestService>();
            services.AddTransient<IMedicalAppointmentService, MedicalAppointmentService>();
            services.AddTransient<ILaboratoryTestResultService, LaboratoryTestResultService>();
            services.AddTransient<ValidateUserSession, ValidateUserSession>();
            #endregion
        }
    }
}
