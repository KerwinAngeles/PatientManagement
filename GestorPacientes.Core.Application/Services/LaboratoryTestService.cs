using AutoMapper;
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
    public class LaboratoryTestService : GenericService<SaveLaboratoryTestViewModel, LaboratoryTestViewModel, LaboratoryTest>, ILaboratoryTestService
    {
        private readonly ILaboratoryTestRepository _laboratoryTestRepository;
        private readonly IMapper _mapper;
        public LaboratoryTestService(ILaboratoryTestRepository laboratoryTestRepository, IMapper mapper) : base(laboratoryTestRepository, mapper) 
        {
            _laboratoryTestRepository = laboratoryTestRepository;
            _mapper = mapper;
        }

    }
}
