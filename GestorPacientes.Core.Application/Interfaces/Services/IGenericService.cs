using GestorPacientes.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel>
        where SaveViewModel : class
        where ViewModel : class
    {
        Task<SaveViewModel> Add(SaveViewModel createProduct);
        Task Update(SaveViewModel updateProduct);
        Task Delete(int id);
        Task<List<ViewModel>> GetAll();
        Task<SaveViewModel> GetById(int id);
    }
}
