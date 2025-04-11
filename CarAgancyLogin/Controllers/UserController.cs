using System.Data.SqlClient;
using System.Configuration;
using CarAgancyLogin.Models;

namespace CarAgancyLogin.Controllers
{
    public class UserController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public bool Register(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password,Phonenumber, Role, Address, Email) VALUES (@Username, @Password,@Phonenumber, @Role, @Address, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password); 
                cmd.Parameters.AddWithValue("@Phonenumber", user.Phonenumber);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Login(string username, string password, string role)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password); 
                cmd.Parameters.AddWithValue("@Role",role);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool ChangePassword(string username, string newHashedPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Password = @Password WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Password", newHashedPassword);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

    }
}
