using GestorPacientes.Core.Application.Helpers;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.Services;
using GestorPacientes.Core.Application.ViewModels.Doctors;
using GestorPacientes.Core.Application.ViewModels.Patients;
using Microsoft.AspNetCore.Mvc;

namespace WebAppGestorPacientes.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly ValidateUserSession _validateUserSession;

        public PatientController(IPatientService patientService, ValidateUserSession validateUser)
        {
            _patientService = patientService;
            _validateUserSession = validateUser;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _patientService.GetAll());
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View("SavePatient", new SavePatientsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePatientsViewModel savePatient)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View("SavePatient", savePatient);
            }

            SavePatientsViewModel patientViewModel = await _patientService.Add(savePatient);

            if (patientViewModel != null && patientViewModel.Id != 0)
            {
                patientViewModel.Photo = UploadFile(savePatient.File, patientViewModel.Id);
                await _patientService.Update(patientViewModel);
            }
            return RedirectToRoute(new { controller = "Patient", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View("SavePatient", await _patientService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePatientsViewModel savePatient)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            if (!ModelState.IsValid)
            {

                return View("SavePatient", savePatient);
            }

            SavePatientsViewModel patientViewModel = await _patientService.GetById(savePatient.Id);
            savePatient.Photo = UploadFile(savePatient.File, savePatient.Id, true, patientViewModel.Photo);

            await _patientService.Update(savePatient);
            return RedirectToRoute(new { controller = "Patient", action = "Index" });

        }


        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _patientService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            string basePath = $"/Images/PatientProfile/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    folder.Delete(true);
                }
                Directory.Delete(path);
            }
            await _patientService.Delete(id);
            return RedirectToRoute(new { controller = "Patient", action = "Index" });
        }

        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string photoUrl = "")
        {
            if (isEditMode)
            {
                if (file == null)
                {
                    return photoUrl;
                }
            }
            string basePath = $"/Images/PatientProfile/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = photoUrl.Split('/');
                string oldImageName = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImageName);
                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }

            return $"{basePath}/{fileName}";
        }
    }
}
