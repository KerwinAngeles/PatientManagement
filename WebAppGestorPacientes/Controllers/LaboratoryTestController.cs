using GestorPacientes.Core.Application.Helpers;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.Services;
using GestorPacientes.Core.Application.ViewModels.LaboratoryTest;
using GestorPacientes.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebAppGestorPacientes.Controllers
{
    public class LaboratoryTestController : Controller
    {
        private readonly ILaboratoryTestService _laboratoryTestService;
        private readonly ValidateUserSession _validateUserSession;
        public LaboratoryTestController(ILaboratoryTestService laboratoryTestService, ValidateUserSession validateUserSession)
        {
            _laboratoryTestService = laboratoryTestService;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _laboratoryTestService.GetAll());
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View("SaveLaboratoryTest", new SaveLaboratoryTestViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveLaboratoryTestViewModel saveLaboratoryTest)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }

            if (!ModelState.IsValid)
            {

                return View("SaveLaboratoryTest", saveLaboratoryTest);
            }

            await _laboratoryTestService.Add(saveLaboratoryTest);
            return RedirectToRoute(new { controller = "LaboratoryTest", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View("SaveLaboratoryTest", await _laboratoryTestService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveLaboratoryTestViewModel saveLaboratoryTest)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            if (!ModelState.IsValid)
            {

                return View("SaveLaboratoryTest", saveLaboratoryTest);
            }

            await _laboratoryTestService.Update(saveLaboratoryTest, saveLaboratoryTest.Id);
            return RedirectToRoute(new { controller = "LaboratoryTest", action = "Index" });

        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _laboratoryTestService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            await _laboratoryTestService.Delete(id);
            return RedirectToRoute(new { controller = "LaboratoryTest", action = "Index" });
        }

    }
}
