using Entities.DTO.CategoriesProject;

namespace Business.Abstract
{
    public interface ICategoriesProjectService
    {
        public Task<IResult> AddAsync(DtoCategoriesProjectInsert data);
        public Task<IResult> UpdateAsync(DtoCategoriesProjectUpdate data);
        public Task<IResult> DeleteAsync(Guid UID);
        public Task<IList<CategoriesProject>> GetAllCategoriesProjectAsync();
        public Task<CategoriesProject> GetAllProjectSingleCategoriesProjectAsync(Guid CategoriesProjectUID);
        public Task<CategoriesProject> GetCategoriesAsync(Guid CategoriesProjectUID);

    }
}
