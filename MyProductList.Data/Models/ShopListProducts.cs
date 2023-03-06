namespace MyProductList.Data.Models
{
    public class ShopListProducts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ShopListId { get; set; }
        public ShopList ShopList { get; set; }
    }
}
