using Microsoft.AspNetCore.Mvc;
using Entities;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Entities.DTO.CategoriesProject;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Yönetici")]
    public class ProjeKategorileriController : Controller
    {
        private readonly ICategoriesProjectService service;
        public ProjeKategorileriController(ICategoriesProjectService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetAllCategoriesProjectAsync().Result);
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(DtoCategoriesProjectInsert data)
        {
            if(ModelState.IsValid)
            {
                ViewBag.Message = service.AddAsync(data).Result;
                return View();
            }
            return View();
        }
        [Route("/admin/ProjeKategorileri/Update/{UID}")]
        public IActionResult Update(Guid UID)
        {
            return View(service.GetAllProjectSingleCategoriesProjectAsync(UID).Result);
        }
        [HttpPost]
        [Route("/admin/ProjeKategorileri/Update/{UID}")]
        public IActionResult Update(Guid UID, DtoCategoriesProjectUpdate data)
        {
            if(ModelState.IsValid)
            {
                ViewBag.Message = service.UpdateAsync(data).Result;
                return View(service.GetAllProjectSingleCategoriesProjectAsync(UID).Result);
            }
            return View(service.GetAllProjectSingleCategoriesProjectAsync(UID).Result);
        }
        [Route("/admin/ProjeKategorileri/Delete/{UID}")]
        public IActionResult Delete(Guid UID)
        {
            var result = service.DeleteAsync(UID).Result;
            TempData["Result"] = result.StatusCode.ToString();
            return Redirect("/admin/ProjeKategorileri");
        }
    }
}
