using Core.Abstract;
namespace Entities.DTO.Abilities
{
    public class DtoAbilitiesUpdate: IDTO
    {
        public Guid UID { get; set; }
        public Guid PersonalInformationUID { get; set; }
        public string Name { get; set; }
        public byte Rating { get; set; } // değerlendirme
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
