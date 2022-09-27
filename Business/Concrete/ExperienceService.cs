using AutoMapper;
using Entities.DTO.Experience;

namespace Business.Concrete
{
    public class ExperienceService : IExperienceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        public ExperienceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IResult> AddAsync(DtoExperienceInsert data)
        {
            var experience = mapper.Map<Experience>(data);
            return await _unitOfWork.RepoExperience.AsyncAdd(experience).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IResult> DeleteAsync(Guid UID)
        {
            return await _unitOfWork.RepoExperience.AsyncDelete(x => x.UID == UID).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<Experience>> GetAllExperienceAsync()
        {
            return await _unitOfWork.RepoExperience.AsyncGetAll();
        }

        public async Task<Experience> GetExperienceAsync(Guid UID)
        {
            return await _unitOfWork.RepoExperience.AsyncGetSingle(x => x.UID == UID);
        }

        public async Task<IResult> UpdateAsync(DtoExperienceUpdate data)
        {
            var experience = mapper.Map<Experience>(data);

            return await _unitOfWork.RepoExperience.AsyncUpdate(experience).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        public async Task<IList<Experience>> GetExperienceByPersonalInformationUIDAsync(Guid personalInformationUID)
        {
            return await _unitOfWork.RepoExperience.AsyncGetAll(x => x.PersonalInformationUID == personalInformationUID);
        }
    }
}
