using Entities.DTO.Experience;

namespace Business.Abstract
{
    public interface IExperienceService
    {
        public Task<IResult> AddAsync(DtoExperienceInsert data);
        public Task<IResult> UpdateAsync(DtoExperienceUpdate data);
        public Task<IResult> DeleteAsync(Guid UID);
        public Task<Experience> GetExperienceAsync(Guid UID);
        public Task<IList<Experience>> GetAllExperienceAsync();
        public Task<IList<Experience>> GetExperienceByPersonalInformationUIDAsync(Guid UID);

    }
}
