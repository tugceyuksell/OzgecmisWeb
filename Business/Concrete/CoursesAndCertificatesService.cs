
using AutoMapper;
using Entities.DTO.CoursesAndCertificates;

namespace Business.Concrete
{
    public class CoursesAndCertificatesService : ICoursesAndCertificatesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        public CoursesAndCertificatesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IResult> AddAsync(DtoCoursesAndCertificatesInsert data)
        {
            var courseAndCertificate = mapper.Map<CoursesAndCertificates>(data);
            return await _unitOfWork.RepoCoursesAndCertificates.AsyncAdd(courseAndCertificate).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IResult> DeleteAsync(Guid UID)
        {
            return await _unitOfWork.RepoCoursesAndCertificates.AsyncDelete(x => x.UID == UID).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<CoursesAndCertificates>> GetAllCoursesAndCertificatesAsync()
        {
            return await _unitOfWork.RepoCoursesAndCertificates.AsyncGetAll();
        }

        public async Task<CoursesAndCertificates> GetCoursesAndCertificatesAsync(Guid UID)
        {
            return await _unitOfWork.RepoCoursesAndCertificates.AsyncGetSingle(x => x.UID == UID);
        }

        public async Task<IResult> UpdateAsync(DtoCoursesAndCertificatesUpdate data)
        {
            var courseAndCertificate = mapper.Map<CoursesAndCertificates>(data);
            return await _unitOfWork.RepoCoursesAndCertificates.AsyncUpdate(courseAndCertificate).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        public async Task<IList<CoursesAndCertificates>> GetCoursesAndCertificatesByPersonalInformationUIDAsync(Guid personalInformationUID)
        {
            return await _unitOfWork.RepoCoursesAndCertificates.AsyncGetAll(x => x.PersonalInformationUID == personalInformationUID);
        }
    }
}
