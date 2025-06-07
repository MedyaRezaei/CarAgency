using CarAgancyLogin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace CarAgancyLogin.Controllers
{
    public class UserController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // سایر متدها همانند قبل (بدون تغییر) - مانند SetDriverAvailability, GetAvailableDriversByVehicleType, و غیره.

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

        public List<User> GetAvailableDriversByVehicleType(string vehicleType)
        {
            List<User> drivers = new List<User>();
            string query = @"SELECT u.Username, u.Phonenumber, u.Email, u.Address, u.Role, u.IsAvailable, u.LicenseNumber
                             FROM Users u
                             INNER JOIN Vehicles v ON u.Username = v.DriverUsername
                             WHERE u.Role = N'راننده' AND u.IsAvailable = 1 AND v.VehicleType = @VehicleType";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@VehicleType", vehicleType);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        drivers.Add(new User
                        {
                            Username = reader["Username"].ToString(),
                            Phonenumber = reader["Phonenumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["Address"].ToString(),
                            Role = reader["Role"].ToString(),
                            LicenseNumber = reader["LicenseNumber"]?.ToString(),
                            IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                        });
                    }
                }
            }
            return drivers;
        }

        public List<User> GetUnavailableDrivers()
        {
            List<User> drivers = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Username, Phonenumber, Email, Address, LicenseNumber FROM Users WHERE Role = N'راننده' AND IsAvailable = 0";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    drivers.Add(new User
                    {
                        Username = reader["Username"].ToString(),
                        Phonenumber = reader["Phonenumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        LicenseNumber = reader["LicenseNumber"].ToString(),
                        IsAvailable = false
                    });
                }
            }
            return drivers;
        }

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
                        Email = reader["Email"].ToString(),
                        LicenseNumber = reader["LicenseNumber"]?.ToString(),
                        IsAvailable = reader["IsAvailable"] != DBNull.Value ? (bool?)Convert.ToBoolean(reader["IsAvailable"]) : null
                    };
                }
                return null;
            }
        }

        public bool Register(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password, Phonenumber, Role, Address, Email, LicenseNumber, IsAvailable) " +
                               "VALUES (@Username, @Password, @Phonenumber, @Role, @Address, @Email, @LicenseNumber, @IsAvailable)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Phonenumber", user.Phonenumber);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                if (user.Role == "راننده")
                {
                    cmd.Parameters.AddWithValue("@LicenseNumber", user.LicenseNumber ?? "");
                    cmd.Parameters.AddWithValue("@IsAvailable", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@LicenseNumber", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsAvailable", DBNull.Value);
                }

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

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
        public bool IsPhoneNumberTaken(string phoneNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Phonenumber = @PhoneNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
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

        public List<User> GetAllAvailableDriversWithDetails()
        {
            List<User> drivers = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Username, Phonenumber, Email, Address, Role, IsAvailable, LicenseNumber FROM Users WHERE Role = N'راننده' AND IsAvailable = 1";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    drivers.Add(new User
                    {
                        Username = reader["Username"].ToString(),
                        Phonenumber = reader["Phonenumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        Role = reader["Role"].ToString(),
                        LicenseNumber = reader["LicenseNumber"]?.ToString(),
                        IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                    });
                }
            }
            return drivers;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

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
                        Email = reader["Email"].ToString(),
                        LicenseNumber = reader["LicenseNumber"]?.ToString(),
                        IsAvailable = reader["IsAvailable"] != DBNull.Value ? (bool?)Convert.ToBoolean(reader["IsAvailable"]) : null
                    };
                }
                return null;
            }

        }

    }
}
