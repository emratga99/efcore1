using System.Linq.Expressions;
using efcore2.Model;

namespace efcore2.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity<int>
    {
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        T? Get(Expression<Func<T, bool>> predicate);
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        int SaveChanges();
    }
}
