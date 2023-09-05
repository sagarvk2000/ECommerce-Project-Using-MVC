using System.ComponentModel.DataAnnotations;

namespace Product_Cate_Crud.Models
{
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Cid { get; set; }
        [Required]
        public string? Cname { get; set; }
    }
}
