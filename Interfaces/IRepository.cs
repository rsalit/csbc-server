using System.Linq;

namespace csbc_server.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Insert(T entity);
        void Delete(T entity);
        //IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }

}
