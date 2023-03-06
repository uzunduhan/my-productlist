namespace MyProductList.ViewModel.ViewModels.ShopList
{
    public class ShopListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsComplete { get; set; } 
        public ICollection<ProductForShopListDetailViewModel>? Products { get; set; }

    }
}
