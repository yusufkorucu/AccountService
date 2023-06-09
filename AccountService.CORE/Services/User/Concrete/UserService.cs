﻿using AccountService.Data.Repository;
using AccountService.Domain.Commands.User;
using AccountService.Domain.Dto;
using AccountService.Domain.Dto.User;
using AccountService.Domain.Infrastructure.Constants;
using AccountService.Domain.Infrastructure.Helper;
using AccountService.Domain.Infrastructure.Utilities;
using AccountService.Domain.Quieries.User;
using AccountService.Domain.Services.User.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Domain.Services.User.Concrete
{
    public class UserService : IUserService
    {
        #region Field
        private readonly IUserRepository _userRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public UserService(IUserRepository userRepository, IMapper mapper, IUserAddressRepository userAddressRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;


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


            if (!PasswordHashHelper.Validate(password: command.Password, passwordHash: user.Password))
                return new AccountApiResponse<UserLoginResponseDto>(isSuccess: false, message: CoreMessage.AuthenticateError);

            //Token oluştur datada dön sonraki tüm işlemlerde token ile gerçekleşecek

            var data = _mapper.Map<Data.Models.User, UserLoginResponseDto>(user);

            return new AccountApiResponse<UserLoginResponseDto>(isSuccess: true, message: CoreMessage.RequestSuccessCompleted, data: data);

        }

        public async Task<AccountApiResponse<UserGeneralResponseDto>> AddUserAddress(UserAddressAddCommand command)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId);

            if (user == null)
                return new AccountApiResponse<UserGeneralResponseDto>(isSuccess: false, message: CoreMessage.FailAdded);

            var model = _mapper.Map<UserAddressAddCommand, Data.Models.UserAddress>(command);

            await _userAddressRepository.AddAsync(model);

            var response = await _userAddressRepository.CompleteAsync();

            if (response == 1)
                return new AccountApiResponse<UserGeneralResponseDto>(isSuccess: true, message: CoreMessage.AddedSuccessfuly);

            return new AccountApiResponse<UserGeneralResponseDto>(isSuccess: false, message: CoreMessage.FailAdded);

        }

        public async Task<AccountApiResponse<List<UserAddressDto>>> GetUserAddressList(UserAddressQuery query)
        {
            // will be Get Signed User Update
            var user = await _userRepository.GetByIdAsync(query.UserId);

            if (user == null)
                return new AccountApiResponse<List<UserAddressDto>>(isSuccess: false, message: CoreMessage.AuthenticateError, data: null);

            var userAddressList = await _userAddressRepository.Where(x => x.UserId == query.UserId).ToListAsync();

            var response = _mapper.Map<List<Data.Models.UserAddress>, List<UserAddressDto>>(userAddressList);

            return new AccountApiResponse<List<UserAddressDto>>(isSuccess: true, message: CoreMessage.RequestSuccessCompleted, data: response);

        }

        #endregion
    }
}
