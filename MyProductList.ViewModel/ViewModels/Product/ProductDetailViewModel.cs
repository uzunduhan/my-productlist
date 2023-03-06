using MyProductList.ViewModel.ViewModels.Category;

namespace MyProductList.ViewModel.ViewModels.Product
{
    public class ProductDetailViewModel
    {
        public string Name { get; set; }
        public double? Price { get; set; }
        public ICollection<CategoryForProductViewModel>? Categories { get; set; }
    }
}
