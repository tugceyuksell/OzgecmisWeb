using Core.Abstract;

namespace Entities.DTO.Abilities
{
    public class DtoAbilitiesInsert : IDTO
    {
        public Guid PersonalInformationUID { get; set; }
        public string Name { get; set; }
        public byte Rating { get; set; } // değerlendirme
        public DateTime? UpdatedDate { get; set; }
    }
}
