using Core.Abstract;

namespace Entities.DTO.CategoriesProject
{
    public class DtoCategoriesProjectUpdate : IDTO
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
