using GestorPacientes.Core.Application.Helpers;
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.ViewModels.Users;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<User> AddAsync(User user)
        {
           user.Password = PasswordEncryption.ComputeSha256(user.Password);
           return await base.AddAsync(user);
        }
        public async Task<User> LoginAsync(LoginViewModel loginViewModel)
        {
            string passwordEncryption = PasswordEncryption.ComputeSha256(loginViewModel.Password);

            User user = await _context.Set<User>().FirstOrDefaultAsync(u => u.UserName == loginViewModel.UserName && u.Password == passwordEncryption);
            return user;
        }
        public async Task<bool> FindByNameAsync(string userName)
        {
            var findName = await _context.Users.FirstOrDefaultAsync(s => s.UserName == userName);
            return findName != null;
        } 

    }
}
