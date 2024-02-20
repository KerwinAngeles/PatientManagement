using GestorPacientes.Core.Application.Helpers;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.LaboratoryTest;
using GestorPacientes.Core.Application.ViewModels.LaboratoryTestResult;
using GestorPacientes.Core.Application.ViewModels.MedicalAppointment;
using GestorPacientes.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAppGestorPacientes.Controllers
{
    public class LaboratoryTestResultController : Controller
    {
        private readonly ILaboratoryTestService _laboratoryTestService;
        private readonly IMedicalAppointmentService _medicalAppointmentService;
        private readonly ILaboratoryTestResultService _laboratoryTestResultService;
        private readonly ValidateUserSession _validateUserSession;
        public LaboratoryTestResultController(ILaboratoryTestService testService, ValidateUserSession validateUserSession, IMedicalAppointmentService medicalAppointmentService, ILaboratoryTestResultService laboratoryTestResultService)
        {
            _laboratoryTestService = testService;
            _validateUserSession = validateUserSession;
            _medicalAppointmentService = medicalAppointmentService;
            _laboratoryTestResultService = laboratoryTestResultService;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _laboratoryTestResultService.GetAll());
        }
        public async Task<IActionResult> Create(int id)
        {
            var medicalId = id;

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }

            List<LaboratoryTestViewModel> laboratoryTest = await _laboratoryTestService.GetAll();
            ViewBag.laboratory = laboratoryTest;

            List<MedicalAppointmentViewModel> medicalAppointmentViewModels = await _medicalAppointmentService.GetAll();
            ViewBag.medical = medicalAppointmentViewModels;

            ViewBag.medicalId = medicalId;

            return View("SaveLaboratoryTestResult", new SaveLaboratoryTestResultViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveLaboratoryTestResultViewModel saveLaboratoryResult)
        {

            List<MedicalAppointmentViewModel> medicalAppointmentViewModels = await _medicalAppointmentService.GetAll();
            ViewBag.medical = medicalAppointmentViewModels;

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }

            await _laboratoryTestResultService.Add(saveLaboratoryResult);

            return RedirectToRoute(new { controller = "MedicalAppointment", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> SearchIdentification(string Identification)
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }

            var identificationViewModel = await _laboratoryTestResultService.GetIdentification(Identification);
            List<LaboratoryTestResultViewModel> labResultViewModel = new List<LaboratoryTestResultViewModel> { identificationViewModel };
            return View("Index", labResultViewModel);
        }

        public async Task<IActionResult> ListLaboratoryResult(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _laboratoryTestResultService.GetListLaboratoryTest(id));
        }

        public IActionResult ReportResult(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            ViewBag.labId = Id;
            return View("ReportResult", new SaveLaboratoryTestResultViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> ReportResult(SaveLaboratoryTestResultViewModel saveLaboratory)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }

            if (string.IsNullOrEmpty(saveLaboratory.Result))
            {
                ModelState.AddModelError("Result", "This input is obligatory");
                return View("ReportResult", saveLaboratory);
            }

            await _laboratoryTestResultService.CompleteResult(saveLaboratory);
            return RedirectToRoute(new { controller = "LaboratoryTestResult", action = "Index" });
        }

        public async Task<IActionResult> LabTestComplete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _laboratoryTestResultService.GetListLaboratoryTestComplete(id));
        }
    }
}
