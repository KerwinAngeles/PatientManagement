using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.MedicalAppointment;
using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Services
{
    public class MedicalAppointmentService : IMedicalAppointmentService
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
        public MedicalAppointmentService(IMedicalAppointmentRepository medicalAppointmentRepository)
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
        }

        public async Task<SaveMedicalAppointmentViewModel> Add(SaveMedicalAppointmentViewModel saveMedicalAppointment)
        {
            MedicalAppointment medicalAppointment = new MedicalAppointment();
            medicalAppointment.Id = saveMedicalAppointment.Id;
            medicalAppointment.Cause = saveMedicalAppointment.Cause;
            medicalAppointment.Date = saveMedicalAppointment.Date;
            medicalAppointment.Hour = saveMedicalAppointment.Hour;
            medicalAppointment.IdPatient = saveMedicalAppointment.PatientId;
            medicalAppointment.IdDoctor = saveMedicalAppointment.DoctorId;
            medicalAppointment.State = saveMedicalAppointment.State;

            medicalAppointment = await _medicalAppointmentRepository.AddAsync(medicalAppointment);

            SaveMedicalAppointmentViewModel medicalAppointmentViewModel = new ();
            medicalAppointmentViewModel.Id = medicalAppointment.Id;
            medicalAppointmentViewModel.Cause = medicalAppointment.Cause;
            medicalAppointmentViewModel.Date = medicalAppointment.Date;
            medicalAppointmentViewModel.Hour = medicalAppointment.Hour;
            medicalAppointmentViewModel.PatientId = medicalAppointment.IdPatient;
            medicalAppointmentViewModel.DoctorId = medicalAppointment.IdDoctor;
            medicalAppointmentViewModel.State = medicalAppointment.State;

            return medicalAppointmentViewModel;
        }

        public async Task Update(SaveMedicalAppointmentViewModel saveMedicalAppointment)
        {
            var medicalAppointment = await _medicalAppointmentRepository.GetById(saveMedicalAppointment.Id);
            medicalAppointment.Id = saveMedicalAppointment.Id;
            medicalAppointment.Cause = saveMedicalAppointment.Cause;
            medicalAppointment.Date = saveMedicalAppointment.Date;
            medicalAppointment.Hour = saveMedicalAppointment.Hour;
            medicalAppointment.IdPatient = saveMedicalAppointment.PatientId;
            medicalAppointment.IdDoctor = saveMedicalAppointment.DoctorId;
            medicalAppointment.State = saveMedicalAppointment.State;

            await _medicalAppointmentRepository.UpdateAsync(medicalAppointment);
        }

        public async Task Delete (int id)
        {
            var medicalAppointment = await _medicalAppointmentRepository.GetById(id);
            await _medicalAppointmentRepository.DeleteAsync(medicalAppointment);
        }

        public async Task DeleteWithLabResult(int id)
        {
            var medicalAppointment = await _medicalAppointmentRepository.GetById(id);
            await _medicalAppointmentRepository.DeleteWithLabResult(medicalAppointment.Id);
        }

        public async Task<List<MedicalAppointmentViewModel>> GetAll()
        {
            var medicalAppointment = await _medicalAppointmentRepository.GetAllWithInclude(new List<string> { "Patient", "Doctor" });
            return medicalAppointment.Select(ma => new MedicalAppointmentViewModel
            {
                Id = ma.Id,
                Cause = ma.Cause,
                Date = ma.Date,
                Hour = ma.Hour,
                PatientName = ma.Patient.Name,
                DoctorName = ma.Doctor.Name,
                State = ma.State,

            }).ToList();
        }

        public async Task<SaveMedicalAppointmentViewModel> GetById(int id)
        {
            var medicalAppointment = await _medicalAppointmentRepository.GetById(id);
            SaveMedicalAppointmentViewModel saveMedicalAppointment = new SaveMedicalAppointmentViewModel()
            {
                Id = medicalAppointment.Id,
                Cause= medicalAppointment.Cause,
                Date = medicalAppointment.Date,
                Hour = medicalAppointment.Hour,
                PatientId = medicalAppointment.IdPatient,
                DoctorId = medicalAppointment.IdDoctor,
                State = medicalAppointment.State
            };

            return saveMedicalAppointment;
        }
    }
}
