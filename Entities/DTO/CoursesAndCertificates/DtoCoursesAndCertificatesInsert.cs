using Core.Abstract;

namespace Entities.DTO.CoursesAndCertificates
{
    public class DtoCoursesAndCertificatesInsert:IDTO
    {
        public Guid PersonalInformationUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
