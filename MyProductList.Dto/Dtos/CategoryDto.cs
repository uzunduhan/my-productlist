using MyProductList.Base.Dto;
using MyProductList.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MyProductList.Dto.Dtos
{
    public class CategoryDto : BaseDto
    {
        [Required]
        public string Name { get; set; }
       // public ICollection<ProductCategory>? Product_Categories { get; set; }
    }
}
