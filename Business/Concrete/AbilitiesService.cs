using AutoMapper;
using Entities.DTO.Abilities;

namespace Business.Concrete
{
    public class AbilitiesService : IAbilitiesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        public AbilitiesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IResult> AddAsync(DtoAbilitiesInsert data)
        {
            var abilities = mapper.Map<Abilities>(data);
            return await _unitOfWork.RepoAbilities.AsyncAdd(abilities).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        public async Task<IResult> DeleteAsync(Guid UID)
        {
            return await _unitOfWork.RepoAbilities.AsyncDelete(x => x.UID == UID).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<Abilities>> GetAllAbilitiesAsync()
        {
            return await _unitOfWork.RepoAbilities.AsyncGetAll();
        }
        public async Task<Abilities> GetAbilitiesAsync(Guid AbilitiesUID)
        {
            return await _unitOfWork.RepoAbilities.AsyncGetSingle(x => x.UID == AbilitiesUID);
        }

        public async Task<IResult> UpdateAsync(DtoAbilitiesUpdate data)
        {
            var abilities = mapper.Map<Abilities>(data);
            return await _unitOfWork.RepoAbilities.AsyncUpdate(abilities).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        public async Task<IList<Abilities>> GetAbilitiesByPersonalInformationUIDAsync(Guid personalInformationUID)
        {
            return await _unitOfWork.RepoAbilities.AsyncGetAll(x => x.PersonalInformationUID == personalInformationUID);
        }
    }
}
