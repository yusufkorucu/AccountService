using AccountService.Data.Enums;
using AccountService.Domain.Dto;
using AccountService.Domain.Infrastructure.Utilities;
using AccountService.Domain.Services.User.Abstract;
using MediatR;

namespace AccountService.Domain.Commands.User
{
    public class UserAddressAddCommand : IRequest<AccountApiResponse<UserGeneralResponseDto>>
    {
        public AddressType AddressType { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string District { get; set; }
        public string Name { get; set; }
        public string FullAddress { get; set; }
        public long UserId { get; set; }


        public class UserAddressAddCommandHandler : IRequestHandler<UserAddressAddCommand, AccountApiResponse<UserGeneralResponseDto>>
        {
            private IUserService _userService;
            public UserAddressAddCommandHandler(IUserService userService)
            {
                _userService = userService;
            }
            public async Task<AccountApiResponse<UserGeneralResponseDto>> Handle(UserAddressAddCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var response = await _userService.AddUserAddress(request);

                    return new AccountApiResponse<UserGeneralResponseDto>(isSuccess: response.IsSuccess, message: response.Message);
                }
                catch (Exception ex)
                {
                    return new AccountApiResponse<UserGeneralResponseDto>(isSuccess: false, message: ex.Message);
                }
            }
        }
    }
}
