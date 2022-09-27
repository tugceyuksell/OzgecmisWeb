using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class CategoriesProjectRepo : Repositories<CategoriesProject>, ICategoriesProjectRepo
    {
        public CategoriesProjectRepo(DbContext context) : base(context)
        {
        }
    }
}
