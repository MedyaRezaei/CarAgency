using CarAgancyLogin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace CarAgancyLogin.Controllers
{
    public class UserController
    {
        // رشته اتصال به دیتابیس از فایل App.config خوانده می‌شود
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // تغییر وضعیت راننده (در دسترس یا مشغول)
        public void SetDriverAvailability(string username, bool isAvailable)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET IsAvailable = @IsAvailable WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IsAvailable", isAvailable ? 1 : 0);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // دریافت لیست رانندگان در دسترس
        public List<User> GetAvailableDrivers()
        {
            List<User> drivers = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Username FROM Users WHERE Role = @Role AND IsAvailable = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Role", "راننده");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    drivers.Add(new User
                    {
                        Username = reader["Username"].ToString()
                    });
                }
            }
            return drivers;
        }

        // دریافت رانندگان مشغول (در دسترس نیستند)
        public List<User> GetUnavailableDrivers()
        {
            List<User> drivers = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Username, Phonenumber, VehicleType, Email, Address FROM Users WHERE Role = @Role AND IsAvailable = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Role", "راننده");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    drivers.Add(new User
                    {
                        Username = reader["Username"].ToString(),
                        Phonenumber = reader["Phonenumber"].ToString(),
                        VehicleType = reader["VehicleType"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        IsAvailable = false
                    });
                }
            }
            return drivers;
        }

        // دریافت راننده بر اساس نام کاربری و رمز و نقش
        public User GetUser(string username, string password, string role)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password AND Role = @Role";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        Phonenumber = reader["Phonenumber"].ToString(),
                        Role = reader["Role"].ToString(),
                        Address = reader["Address"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }

                return null;
            }
        }

        // ثبت‌نام کاربر جدید
        public bool Register(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password, Phonenumber, Role, Address, Email, VehicleType, IsAvailable) " +
                               "VALUES (@Username, @Password, @Phonenumber, @Role, @Address, @Email, @VehicleType, @IsAvailable)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Phonenumber", user.Phonenumber);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                if (user.Role == "راننده")
                {
                    cmd.Parameters.AddWithValue("@VehicleType", user.VehicleType ?? "");
                    cmd.Parameters.AddWithValue("@IsAvailable", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@VehicleType", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsAvailable", DBNull.Value);
                }

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ورود کاربر
        public bool Login(string username, string password, string role)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password AND Role = @Role";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // تغییر رمز عبور
        public bool ChangePassword(string username, string newPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Password = @Password WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // بررسی تکراری بودن نام‌کاربری
        public bool IsUsernameTaken(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // بررسی تکراری بودن ایمیل
        public bool IsEmailTaken(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // رانندگان در دسترس با اطلاعات کامل
        public List<User> GetAllAvailableDriversWithDetails()
        {
            List<User> drivers = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Username, Phonenumber, VehicleType, Email, Address, Role, IsAvailable FROM Users WHERE Role = @Role AND IsAvailable = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Role", "راننده");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    drivers.Add(new User
                    {
                        Username = reader["Username"].ToString(),
                        Phonenumber = reader["Phonenumber"].ToString(),
                        VehicleType = reader["VehicleType"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        Role = reader["Role"].ToString(),
                        IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                    });
                }
            }
            return drivers;
        }

        // رانندگان در دسترس براساس نوع وسیله
        public List<User> GetAvailableDriversByVehicleType(string vehicleType)
        {
            List<User> drivers = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Username FROM Users WHERE Role = @Role AND IsAvailable = 1 AND VehicleType = @VehicleType";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Role", "راننده");
                cmd.Parameters.AddWithValue("@VehicleType", vehicleType);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    drivers.Add(new User
                    {
                        Username = reader["Username"].ToString()
                    });
                }
            }
            return drivers;
        }
    }
}
