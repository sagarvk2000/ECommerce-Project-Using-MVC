using System.Data;
using System.Data.SqlClient;

namespace Product_Cate_Crud.Models
{
    public class RegisterCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public RegisterCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        public int AddRegister(Register reg)
        {
            int result = 0;
            string qry = "insert into Register(username,fullname,email,mobileno,gender,city,state,password,confirmpassword)values(@username,@fullname,@email,@mobileno,@gender,@city,@state,@password,@confirmpassword)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@username", reg.Username);
            cmd.Parameters.AddWithValue("@fullname", reg.FullName);
            cmd.Parameters.AddWithValue("@email", reg.Email);
            cmd.Parameters.AddWithValue("@mobileno", reg.MobileNo);
            cmd.Parameters.AddWithValue("@gender", reg.Gender);
            cmd.Parameters.AddWithValue("@city", reg.City);
            cmd.Parameters.AddWithValue("@state", reg.State);
            cmd.Parameters.AddWithValue("@password", reg.Password);
            cmd.Parameters.AddWithValue("@confirmpassword", reg.ConfirmPassword);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        public IEnumerable<Register> GetUser()
        {
            List<Register> list = new List<Register>();
            string qry = "select * from Register";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Register reg = new Register();
                   reg.UserId = Convert.ToInt32(dr["userid"]);
                    reg.status_id = Convert.ToInt32(dr["status_id"]);
                    reg.Username = dr["userName"].ToString();
                    reg.FullName = dr["fullname"].ToString();
                    reg.Email = dr["email"].ToString();
                    reg.MobileNo = dr["mobileno"].ToString();
                    reg.Gender = dr["gender"].ToString();                   
                   reg.City = dr["city"].ToString();
                   reg.State = dr["state"].ToString();                    
                    reg.Password = dr["password"].ToString();
                    reg.ConfirmPassword = dr["confirmpassword"].ToString();
                    list.Add(reg);
                }
            }
            con.Close();
            return list;
        }
    }
}
