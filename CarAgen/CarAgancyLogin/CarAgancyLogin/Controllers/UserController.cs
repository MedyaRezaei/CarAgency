using System.Data.SqlClient;
using System.Configuration;
using CarAgancyLogin.Models;

namespace CarAgancyLogin.Controllers
{
    public class UserController
    {
        // رشته اتصال به دیتابیس از فایل کانفیگ خوانده می‌شود
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // متد ثبت‌نام کاربر جدید
        public bool Register(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // کوئری درج اطلاعات کاربر جدید در جدول Users
                string query = "INSERT INTO Users (Username, Password,Phonenumber, Role, Address, Email) VALUES (@Username, @Password,@Phonenumber, @Role, @Address, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);

                // تنظیم پارامترهای کوئری از طریق شیء user
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password); 
                cmd.Parameters.AddWithValue("@Phonenumber", user.Phonenumber);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                // باز کردن اتصال و اجرای کوئری
                conn.Open();
                return cmd.ExecuteNonQuery() > 0; // اگر حداقل یک ردیف اضافه شده باشد، عملیات موفق بوده
            }
        }

        // متد ورود کاربر با بررسی نام‌کاربری، رمزعبور و نقش
        public bool Login(string username, string password, string role)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // بررسی وجود کاربر با اطلاعات ورودی
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password AND Role = @Role";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                conn.Open();
                int count = (int)cmd.ExecuteScalar(); // دریافت تعداد کاربران مطابق شرط
                return count > 0; 
            }
        }

        // متد تغییر رمز عبور برای کاربر خاص
        public bool ChangePassword(string username, string newHashedPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Password = @Password WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Password", newHashedPassword);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                int rows = cmd.ExecuteNonQuery(); // تعداد ردیف‌های بروزرسانی شده
                return rows > 0; // اگر رمز تغییر کرده باشد، true بازمی‌گردد
            }
        }

        // بررسی تکراری بودن نام کاربری
        public bool IsUsernameTaken(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                int count = (int)cmd.ExecuteScalar(); // اگر کاربر موجود باشد، مقدار بزرگ‌تر از صفر خواهد بود
                return count > 0;
            }
        }

        // بررسی اینکه ایمیل از قبل ثبت شده یا نه
        public bool IsEmailTaken(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                int count = (int)cmd.ExecuteScalar(); // اگر ایمیل موجود باشد، مقدار بزرگ‌تر از صفر خواهد بود
                return count > 0;
            }
        }


    }
}
