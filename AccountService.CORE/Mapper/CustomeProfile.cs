using AccountService.Data.Models;
using AccountService.Domain.Commands.User;
using AccountService.Domain.Dto.User;
using AutoMapper;

namespace AccountService.Domain.Mapper
{
    public class CustomeProfile : Profile
    {
        public CustomeProfile()
        {
            CreateMap<Data.Models.User, UserAddCommand>().ReverseMap();
            CreateMap<Data.Models.User, UserLoginResponseDto>().ReverseMap();

        }
    }
}
