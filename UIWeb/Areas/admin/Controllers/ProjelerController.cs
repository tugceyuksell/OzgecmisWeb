using Business.Abstract;
using Business.FluentValidations;
using Entities;
using Entities.DTO.Projects;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Yönetici")]
    public class ProjelerController : Controller
    {
        private readonly IProjectService service;
        private readonly ICategoriesProjectService categoriesProjectService;
        private readonly IPersonalInformationService personalInformationService;
        public ProjelerController(IProjectService service, ICategoriesProjectService categoriesProjectService, IPersonalInformationService personalInformationService)
        {
            this.service = service;
            this.categoriesProjectService = categoriesProjectService;
            this.personalInformationService = personalInformationService;
        }
        public IActionResult Index()
        {
            ViewBag.ProjeKategorileri = categoriesProjectService.GetAllCategoriesProjectAsync().Result;
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            return View(service.GetAllProjects().Result);
        }

        public IActionResult Insert()
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            ViewBag.ProjeKategorileri = categoriesProjectService.GetAllCategoriesProjectAsync().Result;
            return View();
        }
        [HttpPost]
        public IActionResult Insert(DtoProjectsInsert data, IFormFile Images)
        {
            FluentProjects val = new();
            var validatorResult = val.Validate(data);
            string AnaResimResponse = Helpers.ImagesUpload.Upload(Images);
            if (AnaResimResponse == "0")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen Jpeg veya Jpg uzantılı resim seçiniz";
            }
            else if (AnaResimResponse == "1")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen resim seçiniz";
            }
            else
            {
                data.Image = AnaResimResponse;
            }

            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            ViewBag.ProjeKategorileri = categoriesProjectService.GetAllCategoriesProjectAsync().Result;

            if (validatorResult.IsValid)
            {
                ViewBag.Message = service.AddAsync(data).Result;
                return View();
            }
            return View();
        }
        [Route("/admin/Projeler/Update/{UID}")]
        public IActionResult Update(Guid UID)
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            ViewBag.ProjeKategorileri = categoriesProjectService.GetAllCategoriesProjectAsync().Result;
            return View(service.GetRelationProjects(UID).Result);
        }
        [HttpPost]
        [Route("/admin/Projeler/Update/{UID}")]
        public IActionResult Update(Guid UID, Projects data, IFormFile Images)
        {
            data.UpdatedDate = DateTime.Now;
            string AnaResimResponse = Helpers.ImagesUpload.Upload(Images);
            if (AnaResimResponse == "0")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen Jpeg veya Jpg uzantılı resim seçiniz";
            }
            else if (AnaResimResponse != "1")
            {
                Helpers.ImagesUpload.ImagesDelete(data.Image);
                data.Image = AnaResimResponse;
            }
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            ViewBag.ProjeKategorileri = categoriesProjectService.GetAllCategoriesProjectAsync().Result;
            if (ModelState.IsValid)
            {
                ViewBag.Message = service.UpdateAsync(data).Result;
                return View(service.GetRelationProjects(UID).Result);
            }
            return View(service.GetRelationProjects(UID).Result);
        }
        [Route("/admin/Projeler/Delete/{UID}")]
        public IActionResult Delete(Guid UID)
        {
            var result = service.DeleteAsync(UID).Result;
            TempData["Result"] = result.StatusCode.ToString();
            return Redirect("/admin/Projeler");
        }
    }
}
