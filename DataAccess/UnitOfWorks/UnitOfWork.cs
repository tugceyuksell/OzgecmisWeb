using Core.Results;
using Core.Results.ComplexTypes;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OzgecmisContext context;
        public UnitOfWork(OzgecmisContext context)
        {
            this.context = context;
        }
        private CategoriesProjectRepo categoriesProject;
        private ProjectsRepo projects;
        private AbilitiesRepo abilities;
        private AboutMeRepo aboutMe;
        private ExperienceRepo experience;
        private PersonalInformationRepo personalInformation;
        private CoursesAndCertificatesRepo coursesAndCertificates;
        private MembersRepo members;
        // Singleton Design (Tek NESNE Yaklaşımı)
        // Kullanılacak Olan Sınıflardan Tek Bir Adet Yönetmemizi isteyen Bir Yaklaşımdır.


        public ICategoriesProjectRepo RepoCategoriesProject => categoriesProject ?? new CategoriesProjectRepo(context);

        public IProjectsRepo RepoProjects => projects ?? new ProjectsRepo(context);

        public IAbilitiesRepo RepoAbilities => abilities ?? new AbilitiesRepo(context);

        public IAboutMeRepo RepoAboutMe => aboutMe ?? new AboutMeRepo(context);

        public IExperienceRepo RepoExperience => experience ?? new ExperienceRepo(context);

        public IPersonalInformationRepo RepoPersonalInformation => personalInformation ?? new PersonalInformationRepo(context);

        public ICoursesAndCertificatesRepo RepoCoursesAndCertificates => coursesAndCertificates ?? new CoursesAndCertificatesRepo(context);
        public IMembersRepo RepoMembers => members ?? new MembersRepo(context);

        public async Task<IResult> SaveChanges()
        {
            // Transaction Kontrolü
            // Birden fazla data aynı anda eklenmek istendiğinde, Datalar'ın hepsinin sorunsuz bir şekilde eklendiğinden emin olmak için kullanılan bir yaklaşımdır.
            using (context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    context.Database.CommitTransaction();
                    return Result.FactoryResult(StatusCode.Success, "İşlem Başarılı");
                }
                catch (Exception e)
                {
                    // Loglama İşlemlerini burada Gerçekleştirebilirsiniz.
                    context.Database.RollbackTransaction();
                    return Result.FactoryResult(StatusCode.Error, "İşlem Başarısız", e);
                }
            }
        }
    }

}

