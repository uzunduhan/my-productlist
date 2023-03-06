using MyProductList.Data.DBOperations;
using MyProductList.Data.Models;
using MyProductList.Data.Repository.Abstract;

namespace MyProductList.Data.Repository.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
