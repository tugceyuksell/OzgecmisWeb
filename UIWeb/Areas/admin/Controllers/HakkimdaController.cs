using Business.Abstract;
using Business.FluentValidations;
using Entities;
using Entities.DTO.AboutMe;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers

{
    [Area("admin"), Authorize(Roles = "Yönetici")]
    public class HakkimdaController : Controller
    {
        private readonly IAboutMeService service;
        private readonly IPersonalInformationService personalInformationService;
        public HakkimdaController(IAboutMeService service, IPersonalInformationService personalInformationService)
        {
            this.service = service;
            this.personalInformationService = personalInformationService;
        }

        public IActionResult Index()
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            return View(service.GetAllAboutMe().Result);
        }
        public IActionResult Insert()
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            return View();
        }
        [HttpPost]
        public IActionResult Insert(DtoAboutMeInsert data, IFormFile ProfilImage, IFormFile BoardImage)  
        {
            FluentAboutMe val = new();
            var validatorResult = val.Validate(data);
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            string ProfilImageResponse = Helpers.ImagesUpload.Upload(ProfilImage);
            if (ProfilImageResponse == "0")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen Jpeg veya Jpg uzantılı resim seçiniz";
            }
            else if (ProfilImageResponse == "1")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen resim seçiniz";
            }
            else
            {
                data.ProfilImage = ProfilImageResponse;
            }
            string ResimAdi = Helpers.ImagesUpload.Upload(BoardImage);
            if (ResimAdi == "0")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen Jpeg veya Jpg uzantılı resim seçiniz";
            }
            else if (ResimAdi == "1")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen resim seçiniz";
            }
            else
            {
                data.BoardImage = ResimAdi;
            }
            if (validatorResult.IsValid)
            {
                ViewBag.Message = service.AddAsync(data).Result;
                return View();
            }
            return View();
        }

        [Route("/admin/hakkimda/update/{UID}")]
        public IActionResult Update(Guid UID)
        {
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            return View(service.GetAboutMeAsync(UID).Result);
        }
        [HttpPost]
        [Route("/admin/hakkimda/update/{UID}")]
        public IActionResult Update(Guid UID, AboutMe data, IFormFile ProfilImages, IFormFile BoardImages)
        {
            data.UpdatedDate = DateTime.Now;
            string AnaResimResponse = Helpers.ImagesUpload.Upload(ProfilImages);
            if (AnaResimResponse == "0")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen Jpeg veya Jpg uzantılı resim seçiniz";
            }
            else if (AnaResimResponse != "1")
            {
                Helpers.ImagesUpload.ImagesDelete(data.ProfilImage);
                data.ProfilImage = AnaResimResponse;
            }

            string ResimAdi = Helpers.ImagesUpload.Upload(BoardImages);
            if (ResimAdi == "0")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen Jpeg veya Jpg uzantılı resim seçiniz";
            }
            else if (ResimAdi != "1")
            {
                Helpers.ImagesUpload.ImagesDelete(data.BoardImage);
                data.BoardImage = ResimAdi;
            }

            ViewBag.Message = service.UpdateAsync(data).Result;
            ViewBag.Kisiler = personalInformationService.GetAllPersonalInformationAsync().Result;
            return View(service.GetAboutMeAsync(UID).Result);
        }
        [Route("/admin/hakkimda/Delete/{UID}")]
        public IActionResult Delete(Guid UID)
        {
            var result = service.DeleteAsync(UID).Result;
            TempData["Result"] = result.StatusCode.ToString();
            return Redirect("/admin/hakkimda");
        }
    }
}
