using AutoMapper;
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
    public class DoctorService : GenericService<SaveDoctorsViewModel, DoctorsViewModel, Doctor>, IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper) : base(doctorRepository, mapper) 
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

    }
}
