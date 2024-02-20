using GestorPacientes.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Helpers
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public ValidateUserSession(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public bool HasUser()
        {
            UserViewModel user = _contextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            if(user == null)
            {
                return false;
            }
            return true;
        }
    }
}
