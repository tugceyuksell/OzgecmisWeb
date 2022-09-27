using Core.Abstract;
namespace Entities
{
    public class AboutMe:IEntity
    {
        public Guid UID { get; set; }
        public Guid PersonalInformationUID { get; set; }
        public string CoverLetter { get; set; } //önyazı
        public string ProfilImage { get; set; }
        public string BoardImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public PersonalInformation PersonalInformation { get; set; }


    }
}
