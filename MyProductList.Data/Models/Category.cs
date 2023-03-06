using MyProductList.Base.Model;

namespace MyProductList.Data.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public ICollection<ProductCategory>? Product_Categories { get; set; }
        public ICollection<ShopList>? ShopLists { get; set; }

    }
}
