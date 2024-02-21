using AutoMapper;
using GestorPacientes.Core.Application.ViewModels.Doctors;
using GestorPacientes.Core.Application.ViewModels.LaboratoryTest;
using GestorPacientes.Core.Application.ViewModels.LaboratoryTestResult;
using GestorPacientes.Core.Application.ViewModels.MedicalAppointment;
using GestorPacientes.Core.Application.ViewModels.Patients;
using GestorPacientes.Core.Application.ViewModels.Users;
using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            #region "User"

            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.RolName, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<User, SaveUserViewModel>()
               .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(dest => dest.Created, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModified, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            #endregion

            #region "Patient"
            CreateMap<Patient, PatientsViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Patient, SavePatientsViewModel>()
               .ForMember(dest => dest.File, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(dest => dest.Created, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModified, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ForMember(dest => dest.Appointments, opt => opt.Ignore())
               .ForMember(dest => dest.Tests, opt => opt.Ignore());
            #endregion

            #region "Doctor"
            CreateMap<Doctor, DoctorsViewModel>()
              .ReverseMap()
              .ForMember(dest => dest.Created, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
              .ForMember(dest => dest.LastModified, opt => opt.Ignore())
              .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());


            CreateMap<Doctor, SaveDoctorsViewModel>()
              .ForMember(dest => dest.File, opt => opt.Ignore())
              .ReverseMap()
              .ForMember(dest => dest.Created, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
              .ForMember(dest => dest.LastModified, opt => opt.Ignore())
              .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
              .ForMember(dest => dest.Appointments, opt => opt.Ignore());
            #endregion

            #region "LaboratoryTest"
            CreateMap<LaboratoryTest, LaboratoryTestViewModel>()
             .ReverseMap();

            CreateMap<LaboratoryTest, SaveLaboratoryTestViewModel>()
            .ReverseMap()
            .ForMember(dest => dest.Tests, opt => opt.Ignore());
            #endregion

            #region "LaboratoryResult"

            CreateMap<LaboratoryTestResult, LaboratoryTestResultViewModel>()
             .ReverseMap();

            CreateMap<LaboratoryTestResult, SaveLaboratoryTestResultViewModel>()
             .ForMember(dest => dest.LaboratoryTests, opt => opt.Ignore())
             .ForMember(dest => dest.Patients, opt => opt.Ignore())
             .ForMember(dest => dest.Appointments, opt => opt.Ignore())
             .ReverseMap()
             .ForMember(dest => dest.Patient, opt => opt.Ignore())
             .ForMember(dest => dest.MedicalAppointment, opt => opt.Ignore())
             .ForMember(dest => dest.Laboratory, opt => opt.Ignore());

            #endregion

            #region "MedicalAppointment"
            CreateMap<MedicalAppointment, MedicalAppointmentViewModel>()
             .ForMember(dest => dest.PatientName, opt => opt.Ignore())
             .ForMember(dest => dest.DoctorName, opt => opt.Ignore())
             .ReverseMap();

            CreateMap<MedicalAppointment, SaveMedicalAppointmentViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.Tests, opt => opt.Ignore());
            #endregion
        }
    }
}
