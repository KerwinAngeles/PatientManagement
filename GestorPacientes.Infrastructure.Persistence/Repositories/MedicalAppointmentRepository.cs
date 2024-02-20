using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Infrastructure.Persistence.Repositories
{
    public class MedicalAppointmentRepository : GenericRepository<MedicalAppointment>, IMedicalAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public MedicalAppointmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteWithLabResult(int id)
        {
            var medicalAppointmentToRemove = await _context.MedicalAppointments
               .Include(m => m.Tests)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (medicalAppointmentToRemove != null)
            {
                _context.LaboratoryTestResults.RemoveRange(medicalAppointmentToRemove.Tests);
                _context.MedicalAppointments.Remove(medicalAppointmentToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}
