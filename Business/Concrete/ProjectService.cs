using AutoMapper;
using Entities.DTO.Projects;

namespace Business.Concrete
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IResult> AddAsync(DtoProjectsInsert data)
        {
            var projects = mapper.Map<Projects>(data);
            return await _unitOfWork.RepoProjects.AsyncAdd(projects).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IResult> DeleteAsync(Guid UID)
        {
            return await _unitOfWork.RepoProjects.AsyncDelete(x=>x.UID== UID).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<Projects>> GetAllProjects()
        {
            return await _unitOfWork.RepoProjects.AsyncGetAll();
        }

        public async Task<Projects> GetRelationProjects(Guid UID)
        {
            return await _unitOfWork.RepoProjects.AsyncGetSingle(x => x.UID == UID, x=>x.CategoriesProject);
        }

        public async Task<IResult> UpdateAsync(Projects data)
        {
            return await _unitOfWork.RepoProjects.AsyncUpdate(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<Projects>> GetProjectsByPersonalInformationUIDAsync(Guid personalInformationUID)
        {
            return await _unitOfWork.RepoProjects.AsyncGetAll(x => x.PersonalInformationUID == personalInformationUID); // PersonalInfUID olarak değiştirilecek
        }
    }
}
