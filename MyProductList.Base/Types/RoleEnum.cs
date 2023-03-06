using System.ComponentModel;

namespace MyProductList.Base.Types
{
    public enum RoleEnum
    {
        [Description(Role.Admin)]
        Admin = 1,

        [Description(Role.User)]
        User = 2
    }

    public class Role
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
