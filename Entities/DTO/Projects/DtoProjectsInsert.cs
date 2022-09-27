using Core.Abstract;
namespace Entities.DTO.Projects
{
    public class DtoProjectsInsert: IDTO
    {
        public Guid CategoriesProjectUID { get; set; }
        public Guid PersonalInformationUID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } //url girilecek
        public string Image { get; set; }
        public string Description { get; set; } // proje açıklaması
    }
}
