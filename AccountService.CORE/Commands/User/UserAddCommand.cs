using AccountService.Domain.Dto;
using AccountService.Domain.Infrastructure.Constants;
using AccountService.Domain.Infrastructure.Utilities;
using AccountService.Domain.Services.User.Abstract;
using MediatR;

namespace AccountService.Domain.Commands.User
{
    public class UserAddCommand : IRequest<AccountApiResponse<UserGeneralResponseDto>>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public class UserAddCommandHandler : IRequestHandler<UserAddCommand, AccountApiResponse<UserGeneralResponseDto>>
        {
            private IUserService _userService;
            public UserAddCommandHandler(IUserService userService)
            {
                _userService = userService;
            }
            public async Task<AccountApiResponse<UserGeneralResponseDto>> Handle(UserAddCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var response = await _userService.AddUserAsync(request);

                    return new AccountApiResponse<UserGeneralResponseDto>(response.IsScucces, response.Message,response);
                }
                catch (Exception ex)
                {
                    //log error 
                    return new AccountApiResponse<UserGeneralResponseDto>(false, string.Concat(CoreMessage.FailAdded, ex.Message));
                }

            }
        }
    }
}
