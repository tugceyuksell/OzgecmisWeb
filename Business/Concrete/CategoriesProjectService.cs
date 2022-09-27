using AutoMapper;
using Entities.DTO.CategoriesProject;

namespace Business.Concrete
{
    public class CategoriesProjectService:ICategoriesProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        public CategoriesProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IResult> AddAsync(DtoCategoriesProjectInsert data)
        {
            var categoriesProject= mapper.Map<CategoriesProject>(data);
            return await _unitOfWork.RepoCategoriesProject.AsyncAdd(categoriesProject).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IResult> DeleteAsync(Guid UID)
        {
            return await _unitOfWork.RepoCategoriesProject.AsyncDelete(x => x.UID == UID).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<CategoriesProject>> GetAllCategoriesProjectAsync()
        {
            return await _unitOfWork.RepoCategoriesProject.AsyncGetAll();
        }

        public async Task<CategoriesProject> GetAllProjectSingleCategoriesProjectAsync(Guid CategoriesProjectUID)
        {
            return await _unitOfWork.RepoCategoriesProject.AsyncGetSingle(x => x.UID == CategoriesProjectUID, x => x.Projects);
        }

        public async Task<CategoriesProject> GetCategoriesAsync(Guid CategoriesProjectUID)
        {
            return await _unitOfWork.RepoCategoriesProject.AsyncGetSingle(x => x.UID == CategoriesProjectUID);
        }

        public async Task<IResult> UpdateAsync(DtoCategoriesProjectUpdate data)
        {
            var categoriesProject = mapper.Map<CategoriesProject>(data);
            return await _unitOfWork.RepoCategoriesProject.AsyncUpdate(categoriesProject).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
    }
}
