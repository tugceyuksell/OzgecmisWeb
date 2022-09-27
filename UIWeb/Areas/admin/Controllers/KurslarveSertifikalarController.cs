using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Entities.DTO.CoursesAndCertificates;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Yönetici")]
    public class KurslarveSertifikalarController :Controller 
    {
       private readonly ICoursesAndCertificatesService service;
       private readonly IPersonalInformationService personalInformationService;

        public KurslarveSertifikalarController(ICoursesAndCertificatesService courseAndCertificate, IPersonalInformationService personalInformationService)
        {
            this.service = courseAndCertificate;
            this.personalInformationService = personalInformationService;
        }
        public IActionResult Index() //Deneyimler listeleniyor.
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;

            return View(service.GetAllCoursesAndCertificatesAsync().Result);
        }
        public IActionResult Insert()
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;

            return View();
        }
        [HttpPost]
        public IActionResult Insert(DtoCoursesAndCertificatesInsert data)
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            if(ModelState.IsValid)
            {
                ViewBag.Message = service.AddAsync(data).Result;
                return View();
            }
            return View();
        }
        [Route("/admin/KurslarveSertifikalar/update/{UID}")]
        public IActionResult Update(Guid UID)
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            return View(service.GetCoursesAndCertificatesAsync(UID).Result);
        }
        [HttpPost]
        [Route("/admin/KurslarveSertifikalar/update/{UID}")]
        public IActionResult Update(Guid UID, DtoCoursesAndCertificatesUpdate data)
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;

            if(ModelState.IsValid)
            {
                ViewBag.Message = service.UpdateAsync(data).Result;
                return View(service.GetCoursesAndCertificatesAsync(UID).Result);
            }
            return View(service.GetCoursesAndCertificatesAsync(UID).Result);
        }
        [Route("/admin/KurslarveSertifikalar/Delete/{UID}")]
        public IActionResult Delete(Guid UID)
        {
            var result = service.DeleteAsync(UID).Result;
            TempData["Result"] = result.StatusCode.ToString();
            return Redirect("/admin/KurslarveSertifikalar");
        }
    }
}
