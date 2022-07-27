using System.Linq.Expressions;

namespace Practice.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        public IQueryable<T> Queryable();
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate);
        public Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        
        public Task<int> InsertAsync(T obj);
        public Task<int> InsertAsync(IEnumerable<T> list);
        public Task<int> UpdateAsync(T obj);
        public Task<int> UpdateAsync(IEnumerable<T> list);
        public Task<int> DeleteAsync(T obj);
        public Task<int> DeleteAsync(IEnumerable<T> list);
    }
}
