using System.ComponentModel.DataAnnotations;

namespace Product_Cate_Crud.Models
{
    public class Cart
    {
        [Key]
        public int Cid { get; set; }
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Quantity { get; set; }
    }
}
