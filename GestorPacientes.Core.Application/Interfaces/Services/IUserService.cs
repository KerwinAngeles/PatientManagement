using GestorPacientes.Core.Application.ViewModels.Users;
using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel, User>
    {
        Task<bool> FindByNameAsync(string UserName);
        Task<List<UserViewModel>> GetAllUserWithRol();
        Task<UserViewModel> LoginAsync(LoginViewModel loginViewModel);

    }
}
