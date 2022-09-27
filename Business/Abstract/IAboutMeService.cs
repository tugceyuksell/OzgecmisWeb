using Entities.DTO.AboutMe;

namespace Business.Abstract
{
    public interface IAboutMeService
    {
        public Task<IResult> AddAsync(DtoAboutMeInsert data);
        public Task<IResult> UpdateAsync(AboutMe data);
        public Task<IResult> DeleteAsync(Guid UID);
        public Task<AboutMe> GetAboutMeAsync(Guid UID);
        public Task<IList<AboutMe>> GetAllAboutMe();
        public Task<AboutMe> GetAboutMeByPersonalInformationUIDAsync(Guid UID);

    }
}
