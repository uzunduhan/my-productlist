namespace MyProductList.Data.Models
{
    public class ShopListMongoDatabaseSettings : IShopListMongoDatabaseSettings
    {
        public string CollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
