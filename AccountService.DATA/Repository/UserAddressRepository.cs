using AccountService.Data.Data;
using AccountService.Data.Models;
using AccountService.Data.Repository.GenericRepository;

namespace AccountService.Data.Repository
{
    public class UserAddressRepository : GenericRepository<UserAddress>,IUserAddressRepository
    {
        private readonly AccountAppDbContext _dbContext;

        public UserAddressRepository(AccountAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
