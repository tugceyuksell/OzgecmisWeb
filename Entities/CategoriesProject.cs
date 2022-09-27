using Core.Abstract;
namespace Entities
{
    public class CategoriesProject:IEntity
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        // Her Bir Kategori'nin Birden Fazla Ürünü Vardır. (Bir'e Çok İlişki)
        public IList<Projects> Projects { get; set; }
    }
}
