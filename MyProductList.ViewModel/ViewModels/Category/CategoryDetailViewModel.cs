using MyProductList.ViewModel.ViewModels.Product;

namespace MyProductList.ViewModel.ViewModels.Category
{
    public class CategoryDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductForCategoryDetailViewModel>? Products { get; set; }
    }
}
