using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.ViewComponents
{
    public class ToplamAktifCv:ViewComponent
    {
        private readonly IPersonalInformationService personalInformationService;
        public ToplamAktifCv(IPersonalInformationService personalInformationService)
        {
            this.personalInformationService = personalInformationService;
        }
        public IViewComponentResult Invoke()
        {
            return View(personalInformationService.GetSumActivePersonalInformationAsync());
        }
    }
}
