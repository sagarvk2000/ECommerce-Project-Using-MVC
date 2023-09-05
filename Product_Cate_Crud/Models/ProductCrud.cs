using System.Data.SqlClient;

namespace Product_Cate_Crud.Models
{
    public class ProductCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public ProductCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
        public IEnumerable<Product> GetProducts()
        {
            List<Product> list = new List<Product>();
            string qry = "select p.*, cat.cname from Product p inner join Category cat on cat.cid = p.cid";
            cmd = new SqlCommand(qry, con);
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
                    pro.Imageurl = dr["imageurl"].ToString();
                    pro.Cid = Convert.ToInt32(dr["cid"]);
                    pro.Cname = dr["cname"].ToString();
                    list.Add(pro);
                }
            }
            con.Close();
            return list;
        }
        public Product GetProductById(int id)
        {
            Product pro = new Product();
            string qry = "select p.*, cat.cname from Product p inner join Category cat on cat.cid = p.cid where p.id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    pro.Id = Convert.ToInt32(dr["id"]);
                    pro.Name = dr["name"].ToString();
                    pro.Price = Convert.ToDouble(dr["price"]);
                    pro.Imageurl = dr["imageurl"].ToString();
                    pro.Cid = Convert.ToInt32(dr["cid"]);
                    pro.Cname = dr["cname"].ToString();
                }
            }
            con.Close();
            return pro;
        }


        public int AddProduct(Product pro)
        {
            int result = 0;
            string qry = "insert into Product values(@name,@price,@imageurl,@cid)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", pro.Name);
            cmd.Parameters.AddWithValue("@price", pro.Price);
            cmd.Parameters.AddWithValue("@imageurl", pro.Imageurl);
            cmd.Parameters.AddWithValue("@cid", pro.Cid);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateProduct(Product pro)
        {
            int result = 0;
            string qry = "update Product set name=@name,price=@price,imageurl=@imageurl,cid=@cid where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", pro.Name);
            cmd.Parameters.AddWithValue("@price", pro.Price);
            cmd.Parameters.AddWithValue("@imageurl", pro.Imageurl);
            cmd.Parameters.AddWithValue("@cid", pro.Cid);
            cmd.Parameters.AddWithValue("@id", pro.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteProduct(int id)
        {
            int result = 0;
            string qry = "delete from Product where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
