using Business.Abstract;
using Entities;
using Entities.DTO.Abilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Yönetici")]
    public class YeteneklerController : Controller
    {
        private readonly IAbilitiesService service;
        private readonly IPersonalInformationService personalInformationService;
        public YeteneklerController(IAbilitiesService service, IPersonalInformationService personalInformationService)
        {
            this.service = service;
            this.personalInformationService = personalInformationService;
        }

        public IActionResult Index()
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            return View(service.GetAllAbilitiesAsync().Result);
        }
        public IActionResult Insert()
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            return View();
        }
        [HttpPost]
        public IActionResult Insert(DtoAbilitiesInsert data)
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            if (ModelState.IsValid)
            {           
                ViewBag.Message = service.AddAsync(data).Result;
                return View();

            }
            return View();
        }
        [Route("/admin/Yetenekler/Update/{UID}")]
        public IActionResult Update(Guid UID)
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            return View(service.GetAbilitiesAsync(UID).Result);
        }
        [HttpPost]
        [Route("/admin/Yetenekler/Update/{UID}")]
        public IActionResult Update(Guid UID, DtoAbilitiesUpdate data)
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            if (ModelState.IsValid)
            {
                ViewBag.Message = service.UpdateAsync(data).Result;
                return View(service.GetAbilitiesAsync(UID).Result);
            }
            return View(service.GetAbilitiesAsync(UID).Result);
        }
        [Route("/admin/Yetenekler/Delete/{UID}")]
        public IActionResult Delete(Guid UID)
        {
            var result = service.DeleteAsync(UID).Result;
            TempData["Result"] = result.StatusCode.ToString();
            return Redirect("/admin/Yetenekler");
        }
    }
}
