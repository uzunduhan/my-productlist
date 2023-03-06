using MyProductList.Base.Dto;
using MyProductList.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MyProductList.Dto.Dtos
{
    public class ProductDto : BaseDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double? Price { get; set; }
       // public ICollection<ProductCategory>? Product_Categories { get; set; }
    }
}
