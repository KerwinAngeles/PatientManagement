using AutoMapper;
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
    public class PatientService : GenericService<SavePatientsViewModel, PatientsViewModel, Patient>, IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository patientRepository, IMapper mapper) : base(patientRepository, mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

    }
}
