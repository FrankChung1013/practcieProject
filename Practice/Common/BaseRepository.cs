using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Practice.Repository;

namespace Practice.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public BaseRepository (DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<T> Queryable()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// 查詢全部資料
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return GetAllAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 查詢部分資料
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return GetManyAsync(predicate).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            query = query.Where(predicate);

            return await query.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 查詢單筆資料
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return GetAsync(predicate).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            query = query.Where(predicate);
            
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        /// <summary>
        /// 新增(單筆)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual int Insert(T obj)
        {
            return InsertAsync(obj).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        public virtual async Task<int> InsertAsync(T obj)
        {
            await _dbContext.Set<T>().AddAsync(obj);

            return 1;
        }

        /// <summary>
        /// 新增(多筆)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual int Insert(IEnumerable<T> list)
        {
            return InsertAsync(list).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        public virtual async Task<int> InsertAsync(IEnumerable<T> list)
        {
            await _dbContext.Set<T>().AddRangeAsync(list);
            return 1;
        }
        
        /// <summary>
        /// 更新(單筆)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual int Update(T obj)
        {
            return UpdateAsync(obj).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<int> UpdateAsync(T obj)
        {
            _dbContext.Set<T>().Update(obj);

            return 1;
        }
        
        /// <summary>
        /// 更新(多筆)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual int Update(IEnumerable<T> list)
        {
            return UpdateAsync(list).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<int> UpdateAsync(IEnumerable<T> list)
        {
           
            _dbContext.Set<T>().UpdateRange(list);

            return 1;
        }
        
        /// <summary>
        /// 刪除(單筆)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual int Delete(T obj)
        {
            return DeleteAsync(obj).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<int> DeleteAsync(T obj)
        {
            _dbContext.Set<T>().Remove(obj);

            return 1;
        }

        /// <summary>
        /// 刪除(多筆)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual int Delete(IEnumerable<T> list)
        {
            return DeleteAsync(list).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<int> DeleteAsync(IEnumerable<T> list)
        {
            _dbContext.Set<T>().RemoveRange(list);

            return 1;
        }
    }
}
