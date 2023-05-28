using AccountService.Data.Enums;
using AccountService.Data.Models.Base;

namespace AccountService.Data.Models
{
    public class UserAddress : BaseEntity
    {
        public AddressType AddressType { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string District { get; set; }
        public string Name { get; set; }
        public string FullAddress { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
