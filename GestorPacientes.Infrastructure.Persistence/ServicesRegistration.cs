using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Infrastructure.Persistence.Context;
using GestorPacientes.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region "Context configuration"
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(db => db.UseInMemoryDatabase("AppDb"));
            }
            else
            {
                var connectionString = configuration.GetConnectionString("Default");
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString,
                    m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            #endregion

            #region "Repository"
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<ILaboratoryTestRepository, LaboratoryTestsRepository>();
            services.AddTransient<IMedicalAppointmentRepository, MedicalAppointmentRepository>();
            services.AddTransient<ILaboratoryTestResultRepository, LaboratoryTestResultRepository>();

            #endregion
        }
    }
}
