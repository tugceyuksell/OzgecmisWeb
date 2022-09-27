using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class AboutMeRepo : Repositories<AboutMe>, IAboutMeRepo
    {
        public AboutMeRepo(DbContext context) : base(context)
        {
        }
    }
}
