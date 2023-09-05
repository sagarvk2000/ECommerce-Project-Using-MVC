using System.ComponentModel.DataAnnotations;

namespace Product_Cate_Crud.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string? Imageurl { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public int Cid { get; set; }
        [Display(Name = "Category Name")]
        public string? Cname { get; set; }
    }
}
