using AccountService.Domain.Dto;
using AccountService.Domain.Dto.User;
using AccountService.Domain.Infrastructure.Constants;
using AccountService.Domain.Infrastructure.Utilities;
using AccountService.Domain.Services.User.Abstract;
using Azure;
using MediatR;

namespace AccountService.Domain.Commands.User
{
    public class UserLoginCommand : IRequest<AccountApiResponse<UserLoginResponseDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, AccountApiResponse<UserLoginResponseDto>>
        {
            private IUserService _userService;
            public UserLoginCommandHandler(IUserService userService)
            {
                _userService = userService;
            }
            public async Task<AccountApiResponse<UserLoginResponseDto>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var response = await _userService.LoginUserAsync(request);

                    return new AccountApiResponse<UserLoginResponseDto>(isSuccess: response.IsSuccess, message: response.Message, data: response.Data);
                }
                catch (Exception ex)
                {
                    //log error 
                    return new AccountApiResponse<UserLoginResponseDto>(isSuccess: false, message: CoreMessage.UnExpectedError, exception: ex);
                }
            }
        }

    }
}
