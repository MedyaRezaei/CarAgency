using CarAgancyLogin.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CarAgancyLogin
{
    public partial class AboutForm : UserControl


    {
        public Action BackToHomePage; // اکشنی برای بازگشت به صفحه اصلی

        public AboutForm()
        {
            InitializeComponent();
        }

        // بارگذاری تعداد رانندگان از جدول Users و نمایش آن در label4
        private void LoadDriverCount()
        {
            string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Role = N'راننده'", conn);
                int driverCount = (int)cmd.ExecuteScalar();
                label4.Text = driverCount.ToString("D8"); // مثلا: 00000005
            }
        }

        // هنگام بارگذاری فرم درباره
        private void AboutForm_Load(object sender, EventArgs e)
        {
            LoadSatisfactionChart(); // نمایش نمودار رضایت مشتریان

            var reservationController = new ReservationController(); 
            int totalReservations = reservationController.GetTotalReservations(); // تعداد کل رزروها
            label6.Text = totalReservations.ToString("D8");

            LoadDriverCount(); // بارگذاری تعداد راننده‌ها

            // تنظیمات گرافیکی برای لیبل تعداد رزروها
            label6.BackColor = Color.White;
            label6.ForeColor = Color.Black;
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.Font = new Font("Tahoma", 14, FontStyle.Bold);

            // تنظیمات گرافیکی برای لیبل تعداد رانندگان
            label4.BackColor = Color.White;
            label4.ForeColor = Color.Black;
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Font = new Font("Tahoma", 14, FontStyle.Bold);


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // بارگذاری داده‌های نظرسنجی و نمایش آن به صورت نمودار دایره‌ای
        private void LoadSatisfactionChart()
        {
            string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
            // دیکشنری برای نگهداری تعداد نظرات هر امتیاز
            Dictionary<int, int> feedbackCounts = new Dictionary<int, int>
        {
            {1, 0}, // خیلی ضعیف
            {2, 0}, // ضعیف
            {3, 0}, // متوسط
            {4, 0}, // خوب
            {5, 0}, // عالی
        };

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Rating, COUNT(*) as Count FROM Feedbacks GROUP BY Rating", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int rating = reader.GetInt32(0);
                    int count = reader.GetInt32(1);
                    if (feedbackCounts.ContainsKey(rating))
                        feedbackCounts[rating] = count;
                }
            }

            // تبدیل مقادیر به لیبل فارسی
            Dictionary<int, string> labels = new Dictionary<int, string>
        {
            {1, "خیلی ضعیف"},
            {2, "ضعیف"},
            {3, "متوسط"},
            {4, "خوب"},
            {5, "عالی"},
        };

            // پاک کردن سری قبلی
            chart1.Series.Clear();
            chart1.Titles.Clear();

            var series = new Series
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true, // نمایش درصدها روی نمودار
                Label = "#PERCENT{P0}" 
            };

            foreach (var item in feedbackCounts)
            {
                if (item.Value > 0)
                {
                    string label = labels[item.Key];  // گرفتن برچسب فارسی
                    series.Points.AddXY(label, item.Value); // افزودن داده به نمودار
                }
            }

            chart1.Series.Add(series);
            chart1.Titles.Add("درصد رضایت مشتریان");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        // کلیک روی دکمه بازگشت
        private void button2_Click(object sender, EventArgs e)
        {
        
            BackToHomePage?.Invoke();  // بازگشت به صفحه‌ی اصلی
        }
    }
    }

