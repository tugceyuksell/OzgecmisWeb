using Core.Abstract;

namespace Entities.DTO.CoursesAndCertificates
{
    public class DtoCoursesAndCertificatesUpdate : IDTO
    {
        public Guid UID { get; set; }
        public Guid PersonalInformationUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
