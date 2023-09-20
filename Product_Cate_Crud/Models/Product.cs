using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? Imageurl { get; set; }
        [Required]
        [Display(Name = "Category Id")]
        public int Cid { get; set; }
        [Display(Name = "Category Name")]
        public string? Cname { get; set; }

        [NotMapped]
        public int Quantity { get; set; }

        [NotMapped]
        public int Cartid { get; set; }
        [NotMapped]
        public int Userid { get; set; }
        [NotMapped]
        public DateTime Datetime { get; set; }
        [NotMapped]
        public int Orderid { get; set; }
    }
}
