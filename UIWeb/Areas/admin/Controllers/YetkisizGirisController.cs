using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    public class YetkisizGirisController: Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
