using AutoMapper;
using Entities.DTO;
using Entities.DTO.PersonalInformation;

namespace Business.Concrete
{
    public class PersonalInformationService : IPersonalInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        public PersonalInformationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IResult> AddAsync(DtoPersonalInformationInsert data)
        {
            var personalInformation = mapper.Map<PersonalInformation>(data);
            return await _unitOfWork.RepoPersonalInformation.AsyncAdd(personalInformation).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IResult> DeleteAsync(Guid UID)
        {
            return await _unitOfWork.RepoPersonalInformation.AsyncDelete(x=>x.UID==UID).ContinueWith(x=> _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<PersonalInformation>> GetAllPersonalInformationAsync()
        {
            return await _unitOfWork.RepoPersonalInformation.AsyncGetAll();
        }

        public async Task<PersonalInformation> GetPersonalInformationAsync(Guid UID)
        {
            return await _unitOfWork.RepoPersonalInformation.AsyncGetSingle(x => x.UID == UID);
        }

        public async Task<IResult> UpdateAsync(DtoPersonalInformationUpdate data)
        {
            var personalInformation = mapper.Map<PersonalInformation>(data);
            return await _unitOfWork.RepoPersonalInformation.AsyncUpdate(personalInformation).ContinueWith(data=> _unitOfWork.SaveChanges()).Result;
        }

        public async Task<DtoPersonalInformation> GetLastPersonalInformationAsync()
        {
            var sonuc = Task.Run(() => mapper.Map <DtoPersonalInformation>(_unitOfWork.RepoPersonalInformation.AsyncGetAll().Result.OrderByDescending(x => x.CreatedDate).FirstOrDefault()));
            return await sonuc;
        }
        public int GetSumActivePersonalInformationAsync()
        {
            var sonuc = _unitOfWork.RepoPersonalInformation.AsyncGetAll(x=>x.Status==true).Result.Count();
            return  sonuc;
        }
        public int GetSumPassivePersonalInformationAsync()
        {
            var sonuc = _unitOfWork.RepoPersonalInformation.AsyncGetAll(x => x.Status == false).Result.Count();
            return sonuc;
        }

    }
}
