using MyProductList.Dto.Dtos;
using MyProductList.ViewModel.ViewModels.ShopList;

namespace MyProductList.Service.Abstract
{
    public interface IShopListService
    {
        Task<ShopListDto> GetSingleShopListByIdAsync(int id, int userId);
        Task<List<ShopListViewModel>> GetAllShopLists(int userId);
        Task<List<ShopListViewModel>> GetAllShopListsForAdmin();
        Task UpdateShopListAsync(int id, ShopListDto updateResource);
        Task DeleteShopListAsync(int userId, int id);
        Task AddShopListAsync(int userId, ShopListDto updateResource);
        Task AddProductToShopList(int userId, AddProductToShopListDto newProduct);
        Task RemoveProductToShopList(int userId, AddProductToShopListDto newProduct);
        Task CheckIsCompleteColumnForShopList(ShopListDto shopList);
    }
}
