using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class ProjectsRepo : Repositories<Projects>, IProjectsRepo
    {
        public ProjectsRepo(DbContext context) : base(context)
        {
        }
    }
}
