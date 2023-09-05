using System.Data.SqlClient;

namespace Product_Cate_Crud.Models
{
    public class CategoryCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public CategoryCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        public IEnumerable<Category> GetCategories()
        {
            List<Category> list = new List<Category>();
            string qry = "select * from Category";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Category c = new Category();
                    c.Cid = Convert.ToInt32(dr["cid"]);
                    c.Cname = dr["cname"].ToString();
                    list.Add(c);
                }
            }
            con.Close();
            return list;
        }
        public Category GetCategoryById(int id)
        {
            Category cat = new Category();
            string qry = "select * from Category where cid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                   cat.Cid = Convert.ToInt32(dr["cid"]);
                    cat.Cname = dr["cname"].ToString();
                }
            }
            con.Close();
            return cat;
        }
        public int AddCategory(Category cat)
        {
            int result = 0;
            string str = "insert into Category values(@cname)";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@cname", cat.Cname);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateCategory(Category cat)
        {
            int result = 0;
            string str = "update Category set cname=@cname where cid=@cid";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@cname", cat.Cname);
            cmd.Parameters.AddWithValue("@cid", cat.Cid);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteCategory(int id)
        {
            int result = 0;
            string str = "delete from  Category where cid=@cid";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@cid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
