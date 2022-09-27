using AutoMapper;
using Entities.DTO.AboutMe;

namespace Business.Concrete
{
    public class AboutMeService : IAboutMeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        public AboutMeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IResult> AddAsync(DtoAboutMeInsert data)
        {
            var aboutMe = mapper.Map<AboutMe>(data);
            return await _unitOfWork.RepoAboutMe.AsyncAdd(aboutMe).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IResult> DeleteAsync(Guid UID)
        {
            return await _unitOfWork.RepoAboutMe.AsyncDelete(x=>x.UID == UID).ContinueWith(x=> _unitOfWork.SaveChanges()).Result;
        }

        public async Task<AboutMe> GetAboutMeAsync(Guid UID)
        {
            return await _unitOfWork.RepoAboutMe.AsyncGetSingle(x => x.UID == UID);
        }

        public async Task<IList<AboutMe>> GetAllAboutMe()
        {
            return await  _unitOfWork.RepoAboutMe.AsyncGetAll();
        }

        public async Task<IResult> UpdateAsync(AboutMe data)
        {
            return await _unitOfWork.RepoAboutMe.AsyncUpdate(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        public async Task<AboutMe> GetAboutMeByPersonalInformationUIDAsync(Guid personalInformationUID)
        {
            return await _unitOfWork.RepoAboutMe.AsyncGetSingle(x => x.PersonalInformationUID == personalInformationUID);
        }
    }
}
