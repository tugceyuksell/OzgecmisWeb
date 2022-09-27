using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class ExperienceRepo : Repositories<Experience>, IExperienceRepo
    {
        public ExperienceRepo(DbContext context) : base(context)
        {
        }
    }
}
