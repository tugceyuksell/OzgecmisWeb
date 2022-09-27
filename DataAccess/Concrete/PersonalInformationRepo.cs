using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class PersonalInformationRepo : Repositories<PersonalInformation>, IPersonalInformationRepo
    {
        public PersonalInformationRepo(DbContext context) : base(context)
        {
        }
    }
}
