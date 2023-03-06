using MyProductList.Base.Model;

namespace MyProductList.Data.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public double? Price { get; set; }
        public ICollection<ProductCategory>? Product_Categories { get; set; }
        public ICollection<ShopListProducts>? ShopList_Products { get; set; }

    }
}
