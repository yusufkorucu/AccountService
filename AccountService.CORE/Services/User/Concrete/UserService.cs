using AccountService.Data.Repository;
using AccountService.Domain.Commands.User;
using AccountService.Domain.Dto;
using AccountService.Domain.Dto.User;
using AccountService.Domain.Infrastructure.Constants;
using AccountService.Domain.Infrastructure.Helper;
using AccountService.Domain.Infrastructure.Utilities;
using AccountService.Domain.Services.User.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace AccountService.Domain.Services.User.Concrete
{
    public class UserService : IUserService
    {
        #region Field
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;


        }
        #endregion

        #region Methods
        public async Task<UserGeneralResponseDto> AddUserAsync(UserAddCommand command)
        {

            var model = _mapper.Map<UserAddCommand, Data.Models.User>(command);

            if (_userRepository.IsExist(command.Email))
                return new UserGeneralResponseDto { IsScucces = false, Message = CoreMessage.Exist };

            model.Password = PasswordHashHelper.Hash(command.Password);
            await _userRepository.AddAsync(model);

            var response = await _userRepository.CompleteAsync();

            if (response == 1)
                return new UserGeneralResponseDto { IsScucces = true, Message = CoreMessage.AddedSuccessfuly };

            return new UserGeneralResponseDto { IsScucces = false, Message = CoreMessage.FailAdded };


        }

        public async Task<AccountApiResponse<UserLoginResponseDto>> LoginUserAsync(UserLoginCommand command)
        {
            var user = await _userRepository.Where(x => x.Email == command.Email).FirstOrDefaultAsync();

            if (user == null)
                return new AccountApiResponse<UserLoginResponseDto>(isSuccess: false, message: CoreMessage.AuthenticateError);


            if (!PasswordHashHelper.Validate(password:command.Password,passwordHash:user.Password))
                return new AccountApiResponse<UserLoginResponseDto>(isSuccess: false, message: CoreMessage.AuthenticateError);

            //Token oluştur datada dön sonraki tüm işlemlerde token ile gerçekleşecek

            var data = _mapper.Map<Data.Models.User, UserLoginResponseDto>(user);

            return new AccountApiResponse<UserLoginResponseDto>(isSuccess: true, message: CoreMessage.RequestSuccessCompleted, data: data);

        }

        #endregion
    }
}
