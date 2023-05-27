using AccountService.Data.Models;
using AccountService.Data.Repository.GenericRepository;

namespace AccountService.Data.Repository
{
    public interface IUserRepository:IGenericRepository<User>
    {
        bool IsExist(string email);
    }
}
