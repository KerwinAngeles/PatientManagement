using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Doctors;
using GestorPacientes.Core.Application.ViewModels.Patients;
using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<SavePatientsViewModel> Add(SavePatientsViewModel savePatient)
        {
            Patient patient = new Patient();
            patient.Id = savePatient.Id;
            patient.Name = savePatient.Name;
            patient.LastName = savePatient.LastName;
            patient.Phone = savePatient.Phone;
            patient.Direction = savePatient.Direction;
            patient.Identification = savePatient.Identification;
            patient.BirthDate = savePatient.BirthDate;
            patient.IsSmoker = savePatient.IsSmoker;
            patient.IsAllergy = savePatient.IsAllergy;
            patient.Photo = savePatient.Photo;

            patient = await _patientRepository.AddAsync(patient);

            SavePatientsViewModel patientViewModel = new();
            patientViewModel.Id = patient.Id;
            patientViewModel.Name = patient.Name;
            patientViewModel.LastName = patient.LastName;
            patientViewModel.Phone = patient.Phone;
            patientViewModel.Direction = patient.Direction;
            patientViewModel.Identification = patient.Identification;
            patientViewModel.BirthDate = patient.BirthDate;
            patientViewModel.IsSmoker = patient.IsSmoker;
            patientViewModel.IsAllergy = patient.IsAllergy;
            patientViewModel.Photo = patient.Photo;

            return patientViewModel;

        }

        public async Task Update(SavePatientsViewModel savePatient)
        {
            var patient = await _patientRepository.GetById(savePatient.Id);
            patient.Id = savePatient.Id;
            patient.Name = savePatient.Name;
            patient.LastName = savePatient.LastName;
            patient.Phone = savePatient.Phone;
            patient.Direction = savePatient.Direction;
            patient.Identification = savePatient.Identification;
            patient.BirthDate = savePatient.BirthDate;
            patient.IsSmoker= savePatient.IsSmoker;
            patient.IsAllergy = savePatient.IsAllergy;
            patient.Photo = savePatient.Photo;

            await _patientRepository.UpdateAsync(patient);
        }

        public async Task Delete(int id)
        {
            var user = await _patientRepository.GetById(id);
            await _patientRepository.DeleteAsync(user);
        }

        public async Task<List<PatientsViewModel>> GetAll()
        {
            var patient = await _patientRepository.GetAll();
            return patient.Select(p => new PatientsViewModel 
            {
                Id = p.Id,
                Name = p.Name,
                LastName = p.LastName,
                Phone = p.Phone,
                Direction = p.Direction,
                Identification = p.Identification,
                BirthDate = p.BirthDate,
                IsSmoker = p.IsSmoker,
                IsAllergy = p.IsAllergy,
                Photo = p.Photo,
            }).ToList();
        }

        public async Task<SavePatientsViewModel> GetById(int id)
        {
            var doctor = await _patientRepository.GetById(id);
            SavePatientsViewModel saveDoctor = new();
            saveDoctor.Id = doctor.Id;
            saveDoctor.Name = doctor.Name;
            saveDoctor.LastName = doctor.LastName;
            saveDoctor.Phone = doctor.Phone;
            saveDoctor.Direction = doctor.Direction;
            saveDoctor.Identification = doctor.Identification;
            saveDoctor.BirthDate = doctor.BirthDate;
            saveDoctor.IsSmoker = doctor.IsSmoker;
            saveDoctor.IsAllergy = doctor.IsAllergy;
            saveDoctor.Photo = doctor.Photo;

            return saveDoctor;
        }

    }
}
