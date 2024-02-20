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
    public class LaboratoryTestResultRepository : GenericRepository<LaboratoryTestResult>, ILaboratoryTestResultRepository
    {
        private readonly ApplicationDbContext _context;
        public LaboratoryTestResultRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<LaboratoryTestResult> GetIdentification(string identification)
        {
            var labResult = await _context.Set<LaboratoryTestResult>()
                .Include(x => x.Patient)
                .Include(x => x.Laboratory)
                .FirstOrDefaultAsync(result => result.Patient.Identification == identification && result.State == "Pending");
            return labResult;
        }

        public async Task<LaboratoryTestResult> GetByIdWithInclude(int id, List<string> includeProperties)
        {
            var query = _context.LaboratoryTestResults.AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(ltr => ltr.Id == id);
        }
    }
}
