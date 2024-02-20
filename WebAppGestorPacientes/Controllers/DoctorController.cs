using GestorPacientes.Core.Application.Helpers;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.Services;
using GestorPacientes.Core.Application.ViewModels.Doctors;
using GestorPacientes.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebAppGestorPacientes.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly ValidateUserSession _validateUserSession;

        public DoctorController(IDoctorService doctorService, ValidateUserSession validateUserSession)
        {
            _doctorService = doctorService;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _doctorService.GetAll());
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View("SaveDoctor", new SaveDoctorsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveDoctorsViewModel saveDoctor)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View("SaveDoctor", saveDoctor);
            }

            SaveDoctorsViewModel doctorViewModel = await _doctorService.Add(saveDoctor);

            if (doctorViewModel != null && doctorViewModel.Id != 0)
            {
                doctorViewModel.Photo = UploadFile(saveDoctor.File, doctorViewModel.Id);
                await _doctorService.Update(doctorViewModel);
            }
            return RedirectToRoute(new { controller = "Doctor", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View("SaveDoctor", await _doctorService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveDoctorsViewModel saveDoctor)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            if (!ModelState.IsValid)
            {

                return View("SaveDoctor", saveDoctor);
            }

            SaveDoctorsViewModel doctorViewModel = await _doctorService.GetById(saveDoctor.Id);
            saveDoctor.Photo = UploadFile(saveDoctor.File, saveDoctor.Id, true, doctorViewModel.Photo);

            await _doctorService.Update(saveDoctor);
            return RedirectToRoute(new { controller = "Doctor", action = "Index" });

        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            return View(await _doctorService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            string basePath = $"/Images/DoctorProfile/{id}";
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
            await _doctorService.Delete(id);
            return RedirectToRoute(new { controller = "Doctor", action = "Index" });
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
            string basePath = $"/Images/DoctorProfile/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if(!Directory.Exists(path))
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
                string [] oldImagePart = photoUrl.Split('/');
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
