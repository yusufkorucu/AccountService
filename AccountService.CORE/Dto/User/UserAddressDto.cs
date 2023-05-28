using AccountService.Data.Enums;

namespace AccountService.Domain.Dto.User
{
    public class UserAddressDto
    {
        public AddressType AddressType { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string District { get; set; }
        public string Name { get; set; }
        public string FullAddress { get; set; }
    }
}
