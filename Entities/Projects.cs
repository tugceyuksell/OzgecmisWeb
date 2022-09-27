using Core.Abstract;

namespace Entities
{
    public class Projects:IEntity
    {
        public Guid UID { get; set; }
        public Guid CategoriesProjectUID { get; set; }
        public Guid PersonalInformationUID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } //url girilecek
        public string Image { get; set; }
        public string Description { get; set; } // proje açıklaması
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public CategoriesProject CategoriesProject { get; set; }
        public PersonalInformation PersonalInformation { get; set; }

    }
}
