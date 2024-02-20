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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> LoginAsync(LoginViewModel loginViewModel)
        {
            var user = await _userRepository.LoginAsync(loginViewModel);

            if (user == null)
            {
                return null;
            }

            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Name = user.Name;
            userViewModel.LastName = user.LastName;
            userViewModel.Email = user.Email;
            userViewModel.UserName = user.UserName;
            userViewModel.Password = user.Password;
            userViewModel.IdRol = user.IdRol;

            return userViewModel;
        }

        public async Task<SaveUserViewModel> Add(SaveUserViewModel saveUser)
        {
            User user = new User();
            user.Name = saveUser.Name;
            user.LastName = saveUser.LastName;
            user.Email = saveUser.Email;
            user.UserName = saveUser.UserName;
            user.Password = saveUser.Password;
            user.IdRol = saveUser.IdRol;

            user = await _userRepository.AddAsync(user);

            SaveUserViewModel userViewModel = new();
            userViewModel.Name = user.Name;
            userViewModel.LastName = user.LastName;
            userViewModel.Email = user.Email;
            userViewModel.UserName = user.UserName;
            userViewModel.Password = user.Password;
            userViewModel.IdRol = user.IdRol;

            return userViewModel;
        }

        public async Task Update(SaveUserViewModel saveUser)
        {
            var userExist = await _userRepository.GetById(saveUser.Id);
            userExist.Id = saveUser.Id;
            userExist.Name = saveUser.Name;
            userExist.LastName = saveUser.LastName;
            userExist.Email = saveUser.Email;
            userExist.UserName = saveUser.UserName;
            userExist.Password = saveUser.Password;
            await _userRepository.UpdateAsync(userExist);
        }

        public async Task Delete(int id)
        {
            var user = await _userRepository.GetById(id);
            await _userRepository.DeleteAsync(user);
        }

        public async Task<List<UserViewModel>> GetAll()
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

        public async Task<SaveUserViewModel> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            SaveUserViewModel saveUserViewModel = new()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password,
                IdRol = user.IdRol
            };
           
            return saveUserViewModel;
        }

        public async Task<bool> FindByNameAsync(string userName)
        {
            return  await _userRepository.FindByNameAsync(userName);
            
        }


    }
}
