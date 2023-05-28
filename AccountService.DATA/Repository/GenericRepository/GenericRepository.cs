using AccountService.Data.Data;
using AccountService.Data.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AccountService.Data.Repository.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        #region Field
        private readonly AccountAppDbContext _dbContext;
        protected DbSet<TEntity> entity => _dbContext.Set<TEntity>();

        #endregion

        #region Ctor
        public GenericRepository(AccountAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        public async Task AddAsync(TEntity entity)
        {
            await this.entity.AddAsync(entity);
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsDelete = true;
            Update(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await this.entity.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<TEntity>> GetListAsync()
        {
            return this.entity.ToListAsync();
        }

        public void Update(TEntity entity)
        {
            this.entity.Update(entity);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return this.entity.AsNoTracking().Where(expression);
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await this.entity.AddRangeAsync(entities);
        }

        public void RemoveRangeAsync(List<TEntity> entities)
        {
            this.entity.RemoveRange(entities);
        }
    }
}
