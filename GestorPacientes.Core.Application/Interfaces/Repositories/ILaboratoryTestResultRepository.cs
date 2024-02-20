using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Interfaces.Repositories
{
    public interface ILaboratoryTestResultRepository : IGenericRepository<LaboratoryTestResult>
    {
        Task<LaboratoryTestResult> GetIdentification(string identification);
        Task<LaboratoryTestResult> GetByIdWithInclude(int id, List<string> includeProperties);
    }
}
