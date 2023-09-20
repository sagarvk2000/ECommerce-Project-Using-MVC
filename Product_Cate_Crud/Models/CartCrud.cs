using System.Data.SqlClient;

namespace Product_Cate_Crud.Models
{
    public class CartCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public CartCrud(IConfiguration configuration)
        {
            this.configuration=configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        public int AddToCart(Cart cart)
        {
            int result = 0;
            string qry = "insert into Cart values(@id,@userid,@quantity)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", cart.Id);
            cmd.Parameters.AddWithValue("@userid", cart.Userid);
            cmd.Parameters.AddWithValue("@quantity", cart.Quantity);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }

        public List<Product> ViewCart(int userid)
        {
            List<Product> products = new List<Product>();
            string qry = "select p.*,c.quantity,c.cartid from Product p join Cart c on c.id=p.id where c.userid=@userid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@userid", userid);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(dr["id"]);
                    product.Name = dr["name"].ToString();
                    product.Price = Convert.ToDouble(dr["price"]);
                    product.Imageurl = dr["imageurl"].ToString();
                    product.Quantity = Convert.ToInt32(dr["quantity"]);
                    product.Cartid = Convert.ToInt32(dr["cartid"]);
                    products.Add(product);
                }
            }
            con.Close();
            return products;
        }
        public int DeleteCart(int Cartid)
        {
            int result = 0;

            string qry = " delete from Cart where cartid=@cartid";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@cartid", Cartid);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }

        public List<Product> MyOrders(int userid)
        {
            List<Product> prod = new List<Product>();
            string qry = "select p.*,ord.* from Product p join Orders ord on ord.id=p.id  where ord.userid=@userid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@userid", userid);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {   
                while (dr.Read())
                {
                    Product pro = new Product();
                    pro.Id = Convert.ToInt32(dr["id"]);
                    pro.Name = dr["name"].ToString();
                    pro.Price = Convert.ToDouble(dr["price"]);
                    pro.Imageurl = dr["imageUrl"].ToString();
                    pro.Quantity = Convert.ToInt32(dr["quantity"]);
                    //pro.Cartid = Convert.ToInt32(dr["cartid"]);
                    pro.Orderid = Convert.ToInt32(dr["orderid"]);
                    pro.Datetime = Convert.ToDateTime(dr["Date_time"]);
                    prod.Add(pro);
                }
            }
            return prod;
        }

        public int AddOrder(Order ord)
        {
            int result = 0;
            string qry = "insert into Orders(id,userid,quantity) values(@id,@userid,@quantity)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", ord.Id);
            cmd.Parameters.AddWithValue("@userid", ord.Userid);
            cmd.Parameters.AddWithValue("@quantity", ord.Quantity);
            //cmd.Parameters.AddWithValue("@cartid", ord.Cartid);
            //cmd.Parameters.AddWithValue("@date_time", ord.Date_time);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result;

        }

        public int RemoveOrder(int Cartid)
        {
             int result = 0;

            string qry = " delete from Cart where cartid=@cartid";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@cartid", Cartid);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }
    }
}
