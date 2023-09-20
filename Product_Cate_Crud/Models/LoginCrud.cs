using System.Data;
using System.Data.SqlClient;

namespace Product_Cate_Crud.Models
{
    public class LoginCrud
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public LoginCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        public Register GetLogin(string username,string password)
        {

            Register reg = new Register();
            string qry = "select * from Register where username=@username and password=@password";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    reg.UserId = Convert.ToInt32(dr["userid"]);
                    reg.Username = dr["username"].ToString();
                    reg.status_id = Convert.ToInt32(dr["status_id"]);
                }
            }
            con.Close();
            return reg;
        }
    }
}
