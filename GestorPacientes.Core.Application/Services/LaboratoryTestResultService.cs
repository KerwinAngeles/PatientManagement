using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.LaboratoryTestResult;
using GestorPacientes.Core.Application.ViewModels.MedicalAppointment;
using GestorPacientes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Services
{
    public class LaboratoryTestResultService : ILaboratoryTestResultService
    {
        private readonly ILaboratoryTestResultRepository _laboratoryTestResult;
        private readonly IMedicalAppointmentService _medicalAppointmentService;
        public LaboratoryTestResultService(ILaboratoryTestResultRepository test, IMedicalAppointmentService medicalAppointmentService)
        {
            _laboratoryTestResult = test;
            _medicalAppointmentService = medicalAppointmentService;
        }

        public async Task<List<LaboratoryTestResultViewModel>> GetAll()
        {
            var laboratoryTest = await _laboratoryTestResult.GetAllWithInclude(new List<string> { "Patient", "Laboratory" });
            return laboratoryTest
                .Where(lb => lb.State == "Pending")
                .Select(ma => new LaboratoryTestResultViewModel
            {
                Id = ma.Id,
                PatientName = ma.Patient.Name,
                PatientLastName = ma.Patient.LastName,
                PatientIdentification = ma.Patient.Identification,
                LaboratoryTestName = ma.Laboratory.Name

            }).ToList();
        }

        public async Task<SaveLaboratoryTestResultViewModel> Add(SaveLaboratoryTestResultViewModel saveLaboratoryResult)
        {
            var medicalAppointment = await _medicalAppointmentService.GetById(saveLaboratoryResult.MedicalAppointmentId);

            foreach (var idLabResult in saveLaboratoryResult.LaboratoryTests)
            {
                var laboratoryResult = new LaboratoryTestResult
                {
                    IdMedicalAppointment = medicalAppointment.Id,
                    IdPatient = medicalAppointment.PatientId,
                    IdLaboratoryTest = idLabResult,
                    State = medicalAppointment.State
                };

                await _laboratoryTestResult.AddAsync(laboratoryResult);
              
            }

            medicalAppointment.State = "Pending Results";
            await _medicalAppointmentService.Update(medicalAppointment);

            return saveLaboratoryResult;

        }
        public async Task<LaboratoryTestResultViewModel> GetIdentification(string identification)
        {
            var labResult = await _laboratoryTestResult.GetIdentification(identification);

            if(labResult != null)
            {
                LaboratoryTestResultViewModel laboratoryTestResultViewModel = new()
                {
                    Id = labResult.Id,
                    PatientName = labResult.Patient.Name,
                    PatientLastName = labResult.Patient.LastName,
                    PatientIdentification= labResult.Patient.Identification,
                    LaboratoryTestName = labResult.Laboratory.Name
                };

                return laboratoryTestResultViewModel;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<LaboratoryTestResultViewModel>> GetListLaboratoryTest(int id)
        {
            var laboratoryTest = await _laboratoryTestResult.GetAllWithInclude(new List<string> { "Patient", "Laboratory" });
            return laboratoryTest.Where(m => m.IdMedicalAppointment == id)
                .Select(ma => new LaboratoryTestResultViewModel
                {
                    Id = ma.Id,
                    LaboratoryTestName = ma.Laboratory.Name,
                    State = ma.State

                }).ToList();
        }

        public async Task CompleteResult(SaveLaboratoryTestResultViewModel labResult)
        {
            var laboratoryTestResult = await _laboratoryTestResult.GetByIdWithInclude(labResult.Id, new List<string> { "MedicalAppointment" });

            if (laboratoryTestResult != null)
            {
                laboratoryTestResult.Result = labResult.Result;
                laboratoryTestResult.State = "Complete";

                if (laboratoryTestResult.MedicalAppointment != null)
                {
                    laboratoryTestResult.MedicalAppointment.State = "Complete";
                }
                await _laboratoryTestResult.UpdateAsync(laboratoryTestResult);
            }
           
        }

        public async Task<List<LaboratoryTestResultViewModel>> GetListLaboratoryTestComplete(int id)
        {
            var laboratoryTest = await _laboratoryTestResult.GetAllWithInclude(new List<string> { "Patient", "Laboratory" });
            return laboratoryTest.Where(m => m.IdMedicalAppointment == id && m.State == "Complete")
                .Select(ma => new LaboratoryTestResultViewModel
                {
                    Id = ma.Id,
                    LaboratoryTestName = ma.Laboratory.Name,
                    Result = ma.Result

                }).ToList();
        }

        public Task Update(SaveLaboratoryTestResultViewModel updateProduct)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Task<SaveLaboratoryTestResultViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
       
    }
}
