using MyProductList.Base.Model;

namespace MyProductList.Data.Models
{
    public class ShopList : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<ShopListProducts>? ShopList_Products { get; set; }
        public bool? IsComplete { get; set; } = false;
    }
}
