using System.ComponentModel.DataAnnotations;

namespace Product_Cate_Crud.Models
{
    public class Register
    {
        [Key]
        public int UserId { get; set; }
        
        public int status_id { get; set; }

        [Required]
        public string? Username { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? MobileNo { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        public string? ConfirmPassword { get; set; }
       
    }
}
