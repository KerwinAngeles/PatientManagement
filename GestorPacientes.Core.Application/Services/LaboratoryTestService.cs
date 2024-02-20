using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.LaboratoryTest;
using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Services
{
    public class LaboratoryTestService : ILaboratoryTestService
    {
        private readonly ILaboratoryTestRepository _laboratoryTestRepository;
        public LaboratoryTestService(ILaboratoryTestRepository laboratoryTestRepository)
        {
            _laboratoryTestRepository = laboratoryTestRepository;
        }

        public async Task<SaveLaboratoryTestViewModel> Add(SaveLaboratoryTestViewModel saveLaboratoryTest)
        {
            LaboratoryTest laboratoryTest = new LaboratoryTest();
            laboratoryTest.Id = saveLaboratoryTest.Id;
            laboratoryTest.Name = saveLaboratoryTest.Name;

            laboratoryTest = await _laboratoryTestRepository.AddAsync(laboratoryTest);

            SaveLaboratoryTestViewModel saveLaboratoryTestViewModel = new SaveLaboratoryTestViewModel();
            saveLaboratoryTestViewModel.Id = laboratoryTest.Id;
            saveLaboratoryTestViewModel.Name = laboratoryTest.Name;

            return saveLaboratoryTestViewModel;
        }

        public async Task Update(SaveLaboratoryTestViewModel saveLaboratoryTest)
        {
            var laboratoryTest = await _laboratoryTestRepository.GetById(saveLaboratoryTest.Id);
            laboratoryTest.Id = saveLaboratoryTest.Id;
            laboratoryTest.Name = saveLaboratoryTest.Name;

            await _laboratoryTestRepository.UpdateAsync(laboratoryTest);
        }

        public async Task Delete(int id)
        {
            var laboratoryTest = await _laboratoryTestRepository.GetById(id);
            await _laboratoryTestRepository.DeleteAsync(laboratoryTest);
        }

        public async Task<List<LaboratoryTestViewModel>> GetAll()
        {
            var laboratoryTest = await _laboratoryTestRepository.GetAll();
            return laboratoryTest.Select(lb => new LaboratoryTestViewModel
            {
                Id = lb.Id,
                Name = lb.Name
            }).ToList();
        }

        public async Task<SaveLaboratoryTestViewModel> GetById(int id)
        {
            var laboratoryTest = await _laboratoryTestRepository.GetById(id);
            SaveLaboratoryTestViewModel saveLaboratoryTest = new()
            {
                Id = laboratoryTest.Id,
                Name = laboratoryTest.Name
            };

            return saveLaboratoryTest;
        }
    }
}
