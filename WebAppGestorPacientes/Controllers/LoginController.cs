using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using GestorPacientes.Core.Application.Helpers;
using GestorPacientes.Core.Domain.Entities;

namespace WebAppGestorPacientes.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ValidateUserSession _validateUserSession;
        public LoginController(IUserService userService, ValidateUserSession validateUserSession)
        {
            _userService = userService;
            _validateUserSession = validateUserSession;
        }

        public IActionResult Index()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

           UserViewModel userVm = await _userService.LoginAsync(loginViewModel);


           if(userVm != null)
           {
                HttpContext.Session.Set<UserViewModel>("user", userVm);
               return RedirectToRoute(new { controller = "Home", action = "Index" });

           }
           else
           {
               ModelState.AddModelError("User Validation", "Incorrect access data");
           }

            return View(loginViewModel);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
    }
}
