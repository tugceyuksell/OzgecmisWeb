using Core.Abstract;

namespace Entities.DTO.CategoriesProject
{
    public class DtoCategoriesProjectInsert:IDTO
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
