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
    public class GenericService<SaveViewModel, ViewModel, Entity> : IGenericService<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<SaveViewModel> Add(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            entity = await _repository.AddAsync(entity);

            SaveViewModel saveVm = _mapper.Map<SaveViewModel>(entity);
            return saveVm;
        }

        public virtual async Task Update(SaveViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _repository.UpdateAsync(entity, id);
        }

        public virtual async Task Delete(int id)
        {
            Entity entity = await _repository.GetById(id);
            await _repository.DeleteAsync(entity);
        }

        public virtual async Task<List<ViewModel>> GetAll()
        {
            var entityList = await _repository.GetAll();
            return _mapper.Map<List<ViewModel>>(entityList);
            
        }

        public virtual async Task<SaveViewModel> GetById(int id)
        {
            Entity entity = await _repository.GetById(id);
            SaveViewModel saveVm = _mapper.Map<SaveViewModel>(entity);
            return saveVm;
        }

    }
}
