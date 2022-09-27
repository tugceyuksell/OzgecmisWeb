using Business.Abstract;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.ViewComponents
{
    public class SonEklenenKisi: ViewComponent
    {

        private readonly IPersonalInformationService personalInformationService;
        public SonEklenenKisi(IPersonalInformationService personalInformationService)
        {
            this.personalInformationService = personalInformationService;
        }
        public IViewComponentResult Invoke()
        {
           var sonKisiBilgisi = personalInformationService.GetLastPersonalInformationAsync().Result;
            return View(sonKisiBilgisi);
        }
    }
}
