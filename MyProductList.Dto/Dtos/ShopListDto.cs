namespace MyProductList.Dto.Dtos
{
    public class ShopListDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        // public int UserId { get; set; }
        //public ICollection<ProductDto>? Products { get; set; }

        public int CategoryId { get; set; }
        public bool? IsComplete { get; set; }
    }
}
