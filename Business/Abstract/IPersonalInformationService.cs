using Entities.DTO;
using Entities.DTO.PersonalInformation;

namespace Business.Abstract
{
    public interface IPersonalInformationService
    {
        public Task<IResult> AddAsync(DtoPersonalInformationInsert data);
        public Task<IResult> UpdateAsync(DtoPersonalInformationUpdate data);
        public Task<IResult> DeleteAsync(Guid UID);
        public Task<PersonalInformation> GetPersonalInformationAsync(Guid UID);
        public Task<IList<PersonalInformation>> GetAllPersonalInformationAsync();
        public Task<DtoPersonalInformation> GetLastPersonalInformationAsync();
        public int GetSumActivePersonalInformationAsync();
        public int GetSumPassivePersonalInformationAsync();

    }
}
