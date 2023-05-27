using AccountService.Data.Data;
using AccountService.Data.Models;
using AccountService.Data.Repository.GenericRepository;

namespace AccountService.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AccountAppDbContext _dbContext;
        public UserRepository(AccountAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsExist(string email)
        {
            var response = this.entity.FirstOrDefault(x => x.Email == email && x.IsDelete==false);

            if (response == null)
                return false;

            return true;
        }
    }
}
