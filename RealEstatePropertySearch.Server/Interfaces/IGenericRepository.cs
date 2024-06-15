using System.Linq.Expressions;

namespace RealEstatePropertySearch.Server.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        int Add(T entity);
        int Update(T entity);
        int Remove(T entity);
    }
}
