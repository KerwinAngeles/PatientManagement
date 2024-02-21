using AutoMapper;
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
    public class MedicalAppointmentService : GenericService<SaveMedicalAppointmentViewModel, MedicalAppointmentViewModel, MedicalAppointment>, IMedicalAppointmentService
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
        private readonly IMapper _mapper;
        public MedicalAppointmentService(IMedicalAppointmentRepository medicalAppointmentRepository, IMapper mapper) : base(medicalAppointmentRepository, mapper)
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
            _mapper = mapper;
        }

        public async Task DeleteWithLabResult(int id)
        {
            var medicalAppointment = await _medicalAppointmentRepository.GetById(id);
            await _medicalAppointmentRepository.DeleteWithLabResult(medicalAppointment.Id);
        }

        public async Task<List<MedicalAppointmentViewModel>> GetAllAppointmetWithPatientAndDoctor()
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
    }
}
