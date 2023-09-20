using System.ComponentModel.DataAnnotations;

namespace Product_Cate_Crud.Models
{
    public class ContactUs
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Comments { get; set; }
    }
}
