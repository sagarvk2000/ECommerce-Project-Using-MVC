using System.ComponentModel.DataAnnotations;

namespace Product_Cate_Crud.Models
{
    public class Role
    {
        [Key]
        public int Rid { get; set; }
        [Required]
        public string? Rname { get; set; }

    }
}
