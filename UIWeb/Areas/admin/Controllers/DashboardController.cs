using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    public class DashboardController:Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
