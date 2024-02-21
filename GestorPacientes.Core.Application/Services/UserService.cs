using AutoMapper;
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Users;
using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Services
{
    public class UserService : GenericService<SaveUserViewModel, UserViewModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> LoginAsync(LoginViewModel loginViewModel)
        {
            var user = await _userRepository.LoginAsync(loginViewModel);

            if (user == null)
            {
                return null;
            }

            UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }

        public async Task<List<UserViewModel>> GetAllUserWithRol()
        {
            var user = await _userRepository.GetAllWithInclude(new List<string> { "Rol"});
                
            return user.Select(u => new UserViewModel
            {
                Id = u.Id,
                Name = u.Name,
                LastName = u.LastName,
                Email = u.Email,
                UserName = u.UserName,
                RolName= u.Rol.Name

            }).ToList();
        }

        public async Task<bool> FindByNameAsync(string userName)
        {
            return  await _userRepository.FindByNameAsync(userName);
            
        }

    }
}
