using Core.Abstract;
namespace Entities.DTO.AboutMe
{
    public class DtoAboutMeInsert: IDTO
    {
        public Guid PersonalInformationUID { get; set; }
        public string CoverLetter { get; set; } //önyazı
        public string ProfilImage { get; set; }
        public string BoardImage { get; set; }
    }
}
