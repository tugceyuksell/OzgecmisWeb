using Business.Abstract;
using Entities;
using Entities.DTO.PersonalInformation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Yönetici")]
    public class KisiBilgileriController : Controller
    {
        private readonly IPersonalInformationService service;
        public KisiBilgileriController(IPersonalInformationService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(service.GetAllPersonalInformationAsync().Result);
        }

        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(DtoPersonalInformationInsert data)
        {
            if(ModelState.IsValid)
            {
                ViewBag.Message = service.AddAsync(data).Result;
                return View();
            }
            return View();
        }
        [Route("/admin/KisiBilgileri/update/{UID}")]
        public IActionResult Update(Guid UID)
        {
            return View(service.GetPersonalInformationAsync(UID).Result);
        }
        [HttpPost]
        [Route("admin/KisiBilgileri/update/{UID}")]
        public IActionResult Update(Guid UID , DtoPersonalInformationUpdate data)
        {
            if(ModelState.IsValid)
            {
                ViewBag.Message = service.UpdateAsync(data).Result;
                return View(service.GetPersonalInformationAsync(UID).Result);
            }
            return View(service.GetPersonalInformationAsync(UID).Result);
        }
        [Route("/admin/KisiBilgileri/Delete/{UID}")]

        public IActionResult Delete(Guid UID)
        {
            var result = service.DeleteAsync(UID).Result;
            TempData["Result"] = result.StatusCode.ToString();
            return Redirect("/admin/KisiBilgileri");
        }
    }
}
