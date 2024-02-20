using GestorPacientes.Core.Application.ViewModels.LaboratoryTestResult;
using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface ILaboratoryTestResultService : IGenericService<SaveLaboratoryTestResultViewModel, LaboratoryTestResultViewModel>
    {
        Task<LaboratoryTestResultViewModel> GetIdentification(string identification);
        Task<List<LaboratoryTestResultViewModel>> GetListLaboratoryTest(int id);

        Task<List<LaboratoryTestResultViewModel>> GetListLaboratoryTestComplete(int id);
        Task CompleteResult(SaveLaboratoryTestResultViewModel labResult);

    }
}
