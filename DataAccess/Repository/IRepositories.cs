using Core.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    //<TEntity> => Bu Sınıf Bir Generic Type'dir. Her türlü Yapı ile çalışabilir anlamındadır.
    // where TEntity:class => Bu Repositories sadece Class Yapılarını kabul edecektir
    //IEntity => Class'lardan sadece IEntity Interface'sinden miras alanları kabul edecektir.
    //deletegate ler sayesinde alt sınıftaki metotları kullanabiliyoruz.
    public interface IRepositories<TEntity> where TEntity : class, IEntity 
    {
        public Task AsyncAdd(TEntity entity);
        public Task AsyncUpdate(TEntity entity);
        public Task<TEntity> AsyncGetSingle(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include); //lambda fonksiyonunu kabul etmesini sağlıyoruz
        //Expression<Func<TEntity, object>>[] include -> ilişkili tablolarıda getir diyoruz
        //params -> sınırsız parametre alabilir.
        //.where(i=>i.Name)
        //Expression<Func<TEntity, bool>> where  Burada where şartı gönderdiğimde bana TEntity döndüreceksin diyoruz
        public Task<IList<TEntity>> AsyncGetAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] include);
        public Task AsyncDelete(Expression<Func<TEntity, bool>> where);
    }
}
