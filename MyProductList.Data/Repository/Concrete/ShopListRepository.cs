using Microsoft.EntityFrameworkCore;
using MyProductList.Data.DBOperations;
using MyProductList.Data.Models;
using MyProductList.Data.Repository.Abstract;
using System.Security.Cryptography.X509Certificates;

namespace MyProductList.Data.Repository.Concrete
{
    public class ShopListRepository : GenericRepository<ShopList>, IShopListRepository
    {
        public ShopListRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<ShopList> GetByIdAsyncWithProductsAsync(int id, int userId)
        {
            return await _context.ShopLists.Include(x => x.ShopList_Products).ThenInclude(x => x.Product).Where(x => x.Id == id && x.UserId == userId).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ShopList>> GetAllWithProductsAsync(int userId)
        {
            return await _context.ShopLists.Include(x => x.ShopList_Products).ThenInclude(x => x.Product).Where(x=>x.UserId == userId).ToListAsync();
        }
        public async Task<IEnumerable<ShopList>> GetAllWithProductsForAdminAsync()
        {
            return await _context.ShopLists.Include(x => x.ShopList_Products).ThenInclude(x => x.Product).ToListAsync();
        }
    }
}
