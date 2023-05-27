using AccountService.Domain.Commands.User;
using AccountService.Domain.Dto;
using AccountService.Domain.Dto.User;
using AccountService.Domain.Infrastructure.Utilities;

namespace AccountService.Domain.Services.User.Abstract
{
    public interface IUserService
    {
        Task<UserGeneralResponseDto> AddUserAsync(UserAddCommand command);
        Task<AccountApiResponse<UserLoginResponseDto>> LoginUserAsync(UserLoginCommand command);
    }
}
