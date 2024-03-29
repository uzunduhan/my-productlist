﻿using MyProductList.Base.Model;

namespace MyProductList.Data.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime LastActivity { get; set; }
        public ICollection<ShopList> ShopLists { get; set; }
    }
}
