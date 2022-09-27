using Core.Abstract;

namespace Entities.DTO.Experience
{
    public class DtoExperienceInsert: IDTO
    {
        public Guid PersonalInformationUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
