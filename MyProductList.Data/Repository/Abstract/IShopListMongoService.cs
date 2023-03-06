using MyProductList.Data.Models;

namespace MyProductList.Data.Repository.Abstract
{
    public interface IShopListMongoService
    {
        List<ShopListMongo> Get();
        ShopListMongo GetShop(string id);
        ShopListMongo Create(ShopListMongo shopListMongo);
        void Update(string id, ShopListMongo shopListMongo);
        void Remove(string id);

    }
}
