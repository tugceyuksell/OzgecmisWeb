using Entities.DTO.CoursesAndCertificates;

namespace Business.Abstract
{
    public interface ICoursesAndCertificatesService
    {
        public Task<IResult> AddAsync(DtoCoursesAndCertificatesInsert data);
        public Task<IResult> UpdateAsync(DtoCoursesAndCertificatesUpdate data);
        public Task<IResult> DeleteAsync(Guid UID);
        public Task<CoursesAndCertificates> GetCoursesAndCertificatesAsync(Guid UID);
        public Task<IList<CoursesAndCertificates>> GetAllCoursesAndCertificatesAsync();
        public Task<IList<CoursesAndCertificates>> GetCoursesAndCertificatesByPersonalInformationUIDAsync(Guid UID);

    }
}
