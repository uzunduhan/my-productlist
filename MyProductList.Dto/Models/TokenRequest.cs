using System.ComponentModel.DataAnnotations;

namespace MyProductList.Dto.Models
{
    public class TokenRequest
    {
        [Required]
        [MaxLength(125)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
