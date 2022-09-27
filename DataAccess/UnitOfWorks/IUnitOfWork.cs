using Core.Results;
using DataAccess.Abstract;

namespace DataAccess.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public ICategoriesProjectRepo RepoCategoriesProject { get; }
        public IProjectsRepo RepoProjects { get; }
        public IAbilitiesRepo RepoAbilities { get; }
        public IAboutMeRepo RepoAboutMe { get; }
        public IExperienceRepo RepoExperience { get; }
        public IPersonalInformationRepo RepoPersonalInformation { get; }
        public ICoursesAndCertificatesRepo RepoCoursesAndCertificates { get; }
        public IMembersRepo RepoMembers { get; }
        public Task<IResult> SaveChanges();

    }
}
