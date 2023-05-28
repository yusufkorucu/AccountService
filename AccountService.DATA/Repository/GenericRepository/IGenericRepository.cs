using AccountService.Data.Models.Base;
using System.Linq.Expressions;

namespace AccountService.Data.Repository.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetListAsync();
        Task<TEntity> GetByIdAsync(long id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(int id);
        Task<int> CompleteAsync();
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        Task AddRangeAsync(List<TEntity> entities);
        void RemoveRangeAsync(List<TEntity> entities);

    }
}
