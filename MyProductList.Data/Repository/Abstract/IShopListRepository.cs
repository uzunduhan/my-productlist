using MyProductList.Data.Models;

namespace MyProductList.Data.Repository.Abstract
{
    public interface IShopListRepository : IGenericRepository<ShopList>
    {
        Task<ShopList> GetByIdAsyncWithProductsAsync(int id, int userId);
        Task<IEnumerable<ShopList>> GetAllWithProductsAsync(int userId);
        Task<IEnumerable<ShopList>> GetAllWithProductsForAdminAsync();

    }
}
