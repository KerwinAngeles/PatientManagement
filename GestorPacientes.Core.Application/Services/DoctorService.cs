using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Doctors;
using GestorPacientes.Core.Application.ViewModels.Users;
using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<SaveDoctorsViewModel> Add(SaveDoctorsViewModel saveDoctor)
        {
            Doctor doctor = new Doctor();
            doctor.Id = saveDoctor.Id;
            doctor.Name = saveDoctor.Name;
            doctor.LastName = saveDoctor.LastName;
            doctor.Email = saveDoctor.Email;
            doctor.Identification = saveDoctor.Identification;
            doctor.Phone = saveDoctor.Phone;
            doctor.Photo = saveDoctor.Photo;

            doctor = await _doctorRepository.AddAsync(doctor);

            SaveDoctorsViewModel doctorViewModel = new();
            doctorViewModel.Id = doctor.Id;
            doctorViewModel.Name = doctor.Name;
            doctorViewModel.LastName = doctor.LastName;
            doctorViewModel.Email = doctor.Email;
            doctorViewModel.Identification = doctor.Identification;
            doctorViewModel.Phone = doctor.Phone;
            doctorViewModel.Photo = doctor.Photo;
            return doctorViewModel;
        }

        public async Task Update(SaveDoctorsViewModel saveDoctor)
        {
            var doctor = await _doctorRepository.GetById(saveDoctor.Id);
            doctor.Id = saveDoctor.Id;
            doctor.Name = saveDoctor.Name;
            doctor.LastName = saveDoctor.LastName;
            doctor.Email = saveDoctor.Email;
            doctor.Identification = saveDoctor.Identification;
            doctor.Phone = saveDoctor.Phone;
            doctor.Photo = saveDoctor.Photo;

            await _doctorRepository.UpdateAsync(doctor);
        }

        public async Task Delete(int id)
        {
            var doctor = await _doctorRepository.GetById(id);
            await _doctorRepository.DeleteAsync(doctor);
        }

        public async Task<List<DoctorsViewModel>> GetAll()
        {
            var doctor = await _doctorRepository.GetAll();
            return doctor.Select(d => new DoctorsViewModel
            {   
                Id = d.Id, 
                Name = d.Name,
                LastName = d.LastName,
                Email = d.Email,
                Identification = d.Identification,
                Phone = d.Phone,
                Photo = d.Photo

            }).ToList();
        }

        public async Task<SaveDoctorsViewModel> GetById(int id)
        {
            var doctor = await _doctorRepository.GetById(id);
            SaveDoctorsViewModel saveDoctorsViewModel = new()
            {
                Id = doctor.Id,
                Name = doctor.Name,
                LastName = doctor.LastName,
                Email = doctor.Email,
                Identification = doctor.Identification,
                Phone = doctor.Phone,
                Photo = doctor.Photo
            };

            return saveDoctorsViewModel;
        }
    }
}
