using AccountService.Domain.Commands.User;
using AccountService.Domain.Dto;
using AccountService.Domain.Dto.User;
using AccountService.Domain.Infrastructure.Utilities;
using AccountService.Domain.Quieries.User;

namespace AccountService.Domain.Services.User.Abstract
{
    public interface IUserService
    {
        Task<UserGeneralResponseDto> AddUserAsync(UserAddCommand command);
        Task<AccountApiResponse<UserLoginResponseDto>> LoginUserAsync(UserLoginCommand command);
        Task<AccountApiResponse<UserGeneralResponseDto>> AddUserAddress(UserAddressAddCommand command);
        Task<AccountApiResponse<List<UserAddressDto>>> GetUserAddressList(UserAddressQuery query);
    }
}
