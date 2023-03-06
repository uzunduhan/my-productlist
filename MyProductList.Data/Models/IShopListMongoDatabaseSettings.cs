namespace MyProductList.Data.Models
{
    public interface IShopListMongoDatabaseSettings
    {
       public string CollectionName { get; set; }
       public string  ConnectionString { get; set; }
       public string DatabaseName { get; set; } 
    }
}
