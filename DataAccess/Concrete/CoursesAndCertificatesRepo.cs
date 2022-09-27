using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class CoursesAndCertificatesRepo : Repositories<CoursesAndCertificates>, ICoursesAndCertificatesRepo
    {
        public CoursesAndCertificatesRepo(DbContext context) : base(context)
        {
        }
    }
}
