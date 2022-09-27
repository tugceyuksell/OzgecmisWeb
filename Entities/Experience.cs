using Core.Abstract;

namespace Entities
{
    public class Experience:IEntity
    {
        public Guid UID { get; set; }
        public Guid PersonalInformationUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartedDate  { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public PersonalInformation PersonalInformation { get; set; }

    }
}
