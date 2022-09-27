using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
namespace UIWeb.Areas.admin.Controllers
{
    public class CikisController:Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            HttpContext.SignOutAsync();
            TempData["CikisMesaji"] = "Güvenli Bir Şekilde Çıkış Yapıldı";
            return Redirect("/Login");
        }
    }
}
