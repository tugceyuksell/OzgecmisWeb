using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess;
using FluentValidation;

namespace Business.DependencyAutoFact
{
    public class AutoFactModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OzgecmisContext>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<AbilitiesService>().As<IAbilitiesService>();
            builder.RegisterType<AboutMeService>().As<IAboutMeService>();
            builder.RegisterType<CoursesAndCertificatesService>().As<ICoursesAndCertificatesService>();
            builder.RegisterType<CategoriesProjectService>().As<ICategoriesProjectService>();
            builder.RegisterType<ExperienceService>().As<IExperienceService>();
            builder.RegisterType<PersonalInformationService>().As<IPersonalInformationService>();
            builder.RegisterType<ProjectService>().As<IProjectService>();
            builder.RegisterType<MembersService>().As<IMembersService>();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //            .AsImplementedInterfaces();


        }
    }
}
