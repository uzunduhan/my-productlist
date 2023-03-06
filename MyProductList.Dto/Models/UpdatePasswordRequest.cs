using System.ComponentModel.DataAnnotations;

namespace MyProductList.Dto.Models
{
    public class UpdatePasswordRequest
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
