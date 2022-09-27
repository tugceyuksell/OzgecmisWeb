using Core.Abstract;

namespace Entities
{
    public class Abilities:IEntity //yetenekler
    {
        public Guid UID { get; set; }
        public Guid PersonalInformationUID { get; set; }
        public string Name { get; set; }
        public byte Rating { get; set; } // değerlendirme
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public PersonalInformation PersonalInformation { get; set; }

    }
}
