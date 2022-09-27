using Core.Abstract;

namespace Entities
{
    public class CoursesAndCertificates:IEntity
    {
        public Guid UID { get; set; }
        public Guid PersonalInformationUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public PersonalInformation PersonalInformation { get; set; }

    }
}
