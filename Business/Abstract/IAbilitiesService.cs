using Entities.DTO.Abilities;

namespace Business.Abstract
{
    public interface IAbilitiesService
    {
        public Task<IResult> AddAsync(DtoAbilitiesInsert data);
        public Task<IResult> UpdateAsync(DtoAbilitiesUpdate data);
        public Task<IResult> DeleteAsync(Guid UID);
        public Task<IList<Abilities>> GetAllAbilitiesAsync();
        public Task<Abilities> GetAbilitiesAsync(Guid AbilitiesUID);
        public Task<IList<Abilities>> GetAbilitiesByPersonalInformationUIDAsync(Guid UID);
    }
}
