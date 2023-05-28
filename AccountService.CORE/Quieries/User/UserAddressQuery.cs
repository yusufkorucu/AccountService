using AccountService.Domain.Commands.User;
using AccountService.Domain.Dto;
using AccountService.Domain.Dto.User;
using AccountService.Domain.Infrastructure.Constants;
using AccountService.Domain.Infrastructure.Utilities;
using AccountService.Domain.Services.User.Abstract;
using MediatR;

namespace AccountService.Domain.Quieries.User
{
    public class UserAddressQuery : IRequest<AccountApiResponse<List<UserAddressDto>>>
    {
        public long UserId { get; set; }

        public class UserAddressQueryHandler : IRequestHandler<UserAddressQuery, AccountApiResponse<List<UserAddressDto>>>
        {
            private IUserService _userService;
            public UserAddressQueryHandler(IUserService userService)
            {
                _userService = userService;
            }
            public async Task<AccountApiResponse<List<UserAddressDto>>> Handle(UserAddressQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var response = await _userService.GetUserAddressList(request);

                    return new AccountApiResponse<List<UserAddressDto>>(isSuccess: response.IsSuccess, message: response.Message, data: response.Data);
                }
                catch (Exception ex)
                {
                    //log error 
                    return new AccountApiResponse<List<UserAddressDto>>(isSuccess: false, message: string.Concat(CoreMessage.UnExpectedError, ex.Message));
                }

            }
        }

    }
}
