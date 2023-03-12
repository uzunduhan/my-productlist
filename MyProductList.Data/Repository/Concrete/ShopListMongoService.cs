using MyProductList.Data.Models;
using MyProductList.Data.Repository.Abstract;
using MongoDB.Driver;

namespace MyProductList.Data.Repository.Concrete
{
    public class ShopListMongoService : IShopListMongoService
    {
        private IMongoCollection<ShopListMongo> _shopList;

        public ShopListMongoService(IShopListMongoDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _shopList = database.GetCollection<ShopListMongo>(settings.CollectionName);
        }
        public ShopListMongo Create(ShopListMongo shopListMongo)
        {

            _shopList.InsertOne(shopListMongo);

            return shopListMongo;
        }

        public List<ShopListMongo> Get()
        {
            return _shopList.Find(shopList => true).ToList();
        }

        public ShopListMongo GetShop(string id)
        {
            return _shopList.Find(shopList => shopList.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _shopList.DeleteOne(shopList => shopList.Id == id);
        }

        public void Update(string id, ShopListMongo shopListMongo)
        {
            _shopList.ReplaceOne(shopList => shopList.Id == id, shopListMongo);
        }
    }
}
