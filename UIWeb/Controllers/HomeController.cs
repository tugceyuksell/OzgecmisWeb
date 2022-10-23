using Business.Abstract;
using Core.Results;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UIWeb.Models;

namespace UIWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonalInformationService service;
        private readonly IAboutMeService aboutMeservice;
        private readonly IAbilitiesService abilitiesService;
        private readonly IExperienceService experienceService;
        private readonly ICoursesAndCertificatesService coursesAndCertificatesService;
        private readonly IProjectService projectService;
        public HomeController(IPersonalInformationService service, IAboutMeService aboutMeservice, IAbilitiesService abilitiesService, IExperienceService experienceService, ICoursesAndCertificatesService coursesAndCertificatesService, IProjectService projectService)
        {
            this.service = service;
            this.aboutMeservice = aboutMeservice;
            this.abilitiesService = abilitiesService;
            this.experienceService = experienceService;
            this.coursesAndCertificatesService = coursesAndCertificatesService;
            this.projectService = projectService;
        }
        public IActionResult Index()
        {
            ViewBag.Hakkimda = aboutMeservice.GetAllAboutMe().Result;
            return View(service.GetAllPersonalInformationAsync().Result);
        }
        [Route("/home/Detail/{UID}")]
        public IActionResult Detail(Guid UID)
        {
            CVBilgileriViewModel model = new CVBilgileriViewModel();
            model.Abilities = abilitiesService.GetAbilitiesByPersonalInformationUIDAsync(UID).Result;
            model.AboutMe = aboutMeservice.GetAboutMeByPersonalInformationUIDAsync(UID).Result;
            model.CoursesAndCertificates = coursesAndCertificatesService.GetCoursesAndCertificatesByPersonalInformationUIDAsync(UID).Result;
            model.Experience = experienceService.GetExperienceByPersonalInformationUIDAsync(UID).Result;
            model.Projects = projectService.GetProjectsByPersonalInformationUIDAsync(UID).Result;
            model.PersonalInformation = service.GetPersonalInformationAsync(UID).Result;
            return View(model);
        }

        [HttpPost]
        public IActionResult SendingToMail(EMailContent model)
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
            TempData["Result"] = true;

            return Redirect("/Home/Detail/"+model.UID);
        }
    }
}
