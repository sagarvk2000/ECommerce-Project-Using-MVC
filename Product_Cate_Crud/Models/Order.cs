namespace Product_Cate_Crud.Models
{
    public class Order
    {
        public int Orderid { get; set; }
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Quantity { get; set; }
        public int Cartid { get; set; }

        public DateTime Date_time { get; set; }
    }
}
