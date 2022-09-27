using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UIWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMembersService service;
        public LoginController(IMembersService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Email, string Password)
        {
            //HttpContext.User.Identities
            var Bulunan = service.LoginAsync(Email, Password).Result;
            if (Bulunan != null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("UID", Bulunan.UID.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, Bulunan.NameSurname));
                claims.Add(new Claim(ClaimTypes.Role, "Yönetici"));
                var UserIdentity = new ClaimsIdentity(claims, "UserInfo");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);
                var CookiesTime = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(15),
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, CookiesTime);
                HttpContext.Session.SetString("fullname", Bulunan.NameSurname);
                TempData["User"] = Email;
                return Redirect("/admin/Dashboard");
            }
            else
            {
                ViewBag.Message = "Böyle bir Kullanıcı bulunamadı";
                return View();
            }

        }
    }
}
