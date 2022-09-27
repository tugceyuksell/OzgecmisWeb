using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class AbilitiesRepo : Repositories<Abilities>,IAbilitiesRepo
    {
        // Base Keyword'u üst sınıfın Yapıcı Metot'una erişip parametre göndermemizi sağlıyor.
        public AbilitiesRepo(DbContext context) : base(context)
        {

        }
    }
}
