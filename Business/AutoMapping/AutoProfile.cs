using AutoMapper;
using Entities.DTO;
using Entities.DTO.Abilities;
using Entities.DTO.AboutMe;
using Entities.DTO.CategoriesProject;
using Entities.DTO.CoursesAndCertificates;
using Entities.DTO.Experience;
using Entities.DTO.PersonalInformation;
using Entities.DTO.Projects;

namespace Business.AutoMapping
{
    public class AutoProfile : Profile
    {
        public AutoProfile()
        {
            //Veritabanından Gelen NESNE, Dto NESNE'sine dönüştürülme istendiğini Kabul et diyoruz.
            CreateMap<PersonalInformation, DtoPersonalInformation>();// Entity To Dto Convert
                                                                     //Veritabanından Gelen NESNE, Dto NESNE'sine dönüştürülme istendiğini Kabul et diyoruz.

            // Bu Sınıf Ayağa Kalktığı Zaman Bütün Dönüştürmeler Aktif Olarak Hazır Bekler.


            // Aşağıdaki Gibi Sistemi Çalıştırmak istiyorsak, Lazy Load Mantığı Kullanmamız gerekmektedir.
            // Sınıf Ayağa Kalktığında Hangisi Kullanıldıysa O Hemen Hazırlanıp işleme Başlasın.

            // Lazy Load => Sistemleri kullanacağı zaman hazır edip, kullanıma sunan dahili bir kütüphanedir. 
            CreateMap<Abilities, DtoAbilitiesInsert>().ReverseMap()
                .ForMember(i => i.UID, s => s.MapFrom(s => Guid.NewGuid()))
                .ForMember(i => i.CreatedDate, s => s.MapFrom(s => DateTime.Now));
            CreateMap<Abilities, DtoAbilitiesUpdate>().ReverseMap()
                .ForMember(i => i.UpdatedDate, s => s.MapFrom(s => DateTime.Now));
            CreateMap<AboutMe, DtoAboutMeInsert>().ReverseMap()
                .ForMember(i => i.UID, s => s.MapFrom(s => Guid.NewGuid()))
                .ForMember(i => i.CreatedDate, s => s.MapFrom(s => DateTime.Now));
            CreateMap<CategoriesProject, DtoCategoriesProjectInsert>().ReverseMap()
                .ForMember(i => i.UID, s => s.MapFrom(s => Guid.NewGuid()))
                .ForMember(i => i.CreatedDate, s => s.MapFrom(s => DateTime.Now));
            CreateMap<CategoriesProject, DtoCategoriesProjectName>().ReverseMap();
            CreateMap<CategoriesProject, DtoCategoriesProjectUpdate>().ReverseMap()
               .ForMember(i => i.UpdatedDate, s => s.MapFrom(s => DateTime.Now));
            CreateMap<CoursesAndCertificates, DtoCoursesAndCertificatesInsert>()
                .ReverseMap()
                .ForMember(i => i.UID, s => s.MapFrom(s => Guid.NewGuid()))
                .ForMember(i => i.CreatedDate, s => s.MapFrom(s => DateTime.Now));
            CreateMap<CoursesAndCertificates, DtoCoursesAndCertificatesUpdate>()
                .ReverseMap()
                .ForMember(i => i.UpdatedDate, s => s.MapFrom(s => DateTime.Now));
            CreateMap<Experience, DtoExperienceInsert>()
                .ReverseMap()
                .ForMember(i => i.UID, s => s.MapFrom(s => Guid.NewGuid()))
                .ForMember(i => i.CreatedDate, s => s.MapFrom(s => DateTime.Now));
            CreateMap<Experience, DtoExperienceUpdate>()
                .ReverseMap()
                .ForMember(i => i.UpdatedDate, s => s.MapFrom(s => DateTime.Now));
            CreateMap<PersonalInformation, DtoPersonalInformationInsert>()
                .ReverseMap()
                .ForMember(i => i.UID, s => s.MapFrom(s => Guid.NewGuid()))
                .ForMember(i => i.CreatedDate, s => s.MapFrom(s => DateTime.Now));
            CreateMap<PersonalInformation, DtoPersonalInformationUpdate>()
                .ReverseMap()
                .ForMember(i => i.UpdatedDate, s => s.MapFrom(s => DateTime.Now));
            CreateMap<Projects, DtoProjectsInsert>()
                .ReverseMap()
                .ForMember(i => i.UID, s => s.MapFrom(s => Guid.NewGuid()))
                .ForMember(i => i.CreatedDate, s => s.MapFrom(s => DateTime.Now));
        }
    }
}
