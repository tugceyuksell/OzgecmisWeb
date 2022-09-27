using Entities.DTO.Projects;

namespace Business.Abstract
{
    public interface IProjectService
    {
        public Task<IResult> AddAsync(DtoProjectsInsert data);
        public Task<IResult> UpdateAsync(Projects data);
        public Task<IResult> DeleteAsync(Guid UID);
        public Task<IList<Projects>> GetAllProjects();
        public Task<Projects> GetRelationProjects(Guid UID); // 1.Projects'e ait 1.CategoriesProject
        public Task<IList<Projects>> GetProjectsByPersonalInformationUIDAsync(Guid UID);
    }
}
