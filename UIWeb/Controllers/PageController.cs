using Microsoft.AspNetCore.Mvc;
using System.Text;
using UIWeb.Models;

namespace UIWeb.Controllers
{
    public class PageController : Controller
    {
        [HttpPost]
        public IActionResult Index(EMailContent model)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                body.AppendLine("Ad & Soyad: " + model.Name);
                body.AppendLine("E-Mail Adresi: " + model.Email);
                body.AppendLine("Konu: " + model.Subject);
                body.AppendLine("Mesaj: " + model.Message);
                Mail.MailSender(body.ToString());
            }
            return View();
        }
    }
}
