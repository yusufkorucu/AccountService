﻿using AccountService.Data.Models.Base;

namespace AccountService.Data.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserAddress> UserAddresses { get; set; }
    }
}
