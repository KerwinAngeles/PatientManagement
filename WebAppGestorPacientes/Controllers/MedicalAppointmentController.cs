using GestorPacientes.Core.Application.Helpers;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.Services;
using GestorPacientes.Core.Application.ViewModels.Doctors;
using GestorPacientes.Core.Application.ViewModels.MedicalAppointment;
using GestorPacientes.Core.Application.ViewModels.Patients;
using GestorPacientes.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace WebAppGestorPacientes.Controllers
{
    public class MedicalAppointmentController : Controller
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly ValidateUserSession _validateUserSession;
        public MedicalAppointmentController(IMedicalAppointmentService medicalAppointmentService, ValidateUserSession validateUserSession, IPatientService patientService, IDoctorService doctorService)
        {
            _medicalAppointmentService = medicalAppointmentService;
            _validateUserSession = validateUserSession;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _medicalAppointmentService.GetAllAppointmetWithPatientAndDoctor());
        }

        public async Task<IActionResult> Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }

            List<PatientsViewModel> patients = await _patientService.GetAll();
            List<DoctorsViewModel> doctors = await _doctorService.GetAll();

            ViewBag.patient = patients;
            ViewBag.doctor = doctors;


            return View("SaveMedicalAppointment",new SaveMedicalAppointmentViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveMedicalAppointmentViewModel saveMedicalAppointment)
        {
            List<PatientsViewModel> patients = await _patientService.GetAll();
            List<DoctorsViewModel> doctors = await _doctorService.GetAll();

            ViewBag.patient = patients;
            ViewBag.doctor = doctors;

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View("SaveMedicalAppointment", saveMedicalAppointment);
            }

            await _medicalAppointmentService.Add(saveMedicalAppointment);
            return RedirectToRoute(new { controller = "MedicalAppointment", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _medicalAppointmentService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            await _medicalAppointmentService.DeleteWithLabResult(id);
            return RedirectToRoute(new { controller = "MedicalAppointment", action = "Index" });
        }
    }
}
