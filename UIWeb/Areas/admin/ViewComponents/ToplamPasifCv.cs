using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.ViewComponents
{
    public class ToplamPasifCv:ViewComponent
    {
        private readonly IPersonalInformationService personalInformationService;
        public ToplamPasifCv(IPersonalInformationService personalInformationService)
        {
            this.personalInformationService = personalInformationService;
        }
        public IViewComponentResult Invoke()
        {
            return View(personalInformationService.GetSumPassivePersonalInformationAsync());
        }
    }
}
