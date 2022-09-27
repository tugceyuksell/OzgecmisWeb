using Business.Abstract;
using Entities;
using Entities.DTO.Experience;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Yönetici")]
    public class DeneyimController : Controller
    {
        private readonly IExperienceService service;
        private readonly IPersonalInformationService personalInformationService;

        public DeneyimController(IExperienceService service, IPersonalInformationService personalInformationService)
        {
            this.service = service;
            this.personalInformationService = personalInformationService;
        }
        public IActionResult Index() //Deneyimler listeleniyor.
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            return View(service.GetAllExperienceAsync().Result);
        }
        public IActionResult Insert()
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;

            return View();
        }
        [HttpPost]
        public IActionResult Insert(DtoExperienceInsert data)
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            if (ModelState.IsValid)
            {
                ViewBag.Message = service.AddAsync(data).Result;
                return View();
            }
            return View();
        }
        [Route("/admin/deneyim/update/{UID}")]
        public IActionResult Update(Guid UID)
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            return View(service.GetExperienceAsync(UID).Result);
        }
        [HttpPost]
        [Route("/admin/deneyim/update/{UID}")]
        public IActionResult Update(Guid UID, DtoExperienceUpdate data)
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            if (ModelState.IsValid)
            {
                ViewBag.Message = service.UpdateAsync(data).Result;
                return View(service.GetExperienceAsync(UID).Result);
            }
            return View(service.GetExperienceAsync(UID).Result);
        }
        [Route("/admin/deneyim/Delete/{UID}")]
        public IActionResult Delete(Guid UID)
        {
            var result = service.DeleteAsync(UID).Result;
            TempData["Result"] = result.StatusCode.ToString();
            return Redirect("/admin/Deneyim");
        }
    }
}
