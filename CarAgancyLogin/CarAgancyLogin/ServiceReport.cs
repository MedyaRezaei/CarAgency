using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class ServiceReport : UserControl
    {
        // رشته اتصال به دیتابیس
        private string connectionString = @"Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
        // ذخیره نام کاربری وارد شده
        private string loggedInUsername;
        // تاریخ پیش‌فرض (تاریخ امروز)
        private DateTime defaultDate = DateTime.Now.Date;

        public ServiceReport(string username)
        {
            InitializeComponent();
            this.loggedInUsername = username; // مقداردهی نام کاربری
        }

        private void ServiceReport_Load(object sender, EventArgs e)
        {
            LoadDrivers(); // بارگذاری لیست رانندگان
            dtpServiceDate.Value = defaultDate; // مقداردهی اولیه به کنترل تاریخ
            LoadAllReservations(); // بارگذاری همه رزروها
        }

        private void LoadDrivers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // باز کردن اتصال به دیتابیس
                string query = "SELECT DISTINCT DriverUsername FROM Reservations"; // کوئری برای گرفتن نام‌های رانندگان بدون تکرار
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();  // اجرای کوئری و گرفتن نتایج

                cmbDrivers.Items.Clear();
                cmbDrivers.Items.Add("همه راننده‌ها");

                while (reader.Read()) // خواندن داده‌ها
                {
                    cmbDrivers.Items.Add(reader["DriverUsername"].ToString());
                }

                cmbDrivers.SelectedIndex = 0; // خواندن داده‌ها
            }
        }

        // متد بارگذاری اطلاعات رزروها (امکان فیلتر براساس تاریخ و راننده)
        private void LoadAllReservations(string dateFilter = null, string driverFilter = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Reservations WHERE 1 = 1";

                if (!string.IsNullOrEmpty(dateFilter)) // در صورت وجود فیلتر تاریخ، اضافه کردن شرط تاریخ به کوئری
                {
                    query += " AND CAST(ReservationDate AS DATE) = @Date";
                }

                // در صورت وجود فیلتر راننده، اضافه کردن شرط راننده به کوئری
                if (!string.IsNullOrEmpty(driverFilter) && driverFilter != "همه راننده‌ها")
                {
                    query += " AND DriverUsername = @Driver";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                // تنظیم پارامتر تاریخ در صورت وجود فیلتر
                if (!string.IsNullOrEmpty(dateFilter))
                    cmd.Parameters.AddWithValue("@Date", dateFilter);

                // تنظیم پارامتر راننده در صورت وجود فیلتر

                if (!string.IsNullOrEmpty(driverFilter) && driverFilter != "همه راننده‌ها")
                    cmd.Parameters.AddWithValue("@Driver", driverFilter);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(); // جدول داده‌ها
                adapter.Fill(dt); // پر کردن جدول با داده‌های رزرو

                dgvServices.DataSource = dt;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedDriver = cmbDrivers.SelectedItem?.ToString(); // گرفتن راننده انتخاب‌شده

            string selectedDate = null;
            // در صورت تغییر تاریخ از حالت پیش‌فرض، مقداردهی فیلتر تاریخ
            if (dtpServiceDate.Value.Date != defaultDate)
            {
                selectedDate = dtpServiceDate.Value.Date.ToString("yyyy-MM-dd");
            }
            // بارگذاری رزروها با فیلترهای اعمال‌شده
            LoadAllReservations(selectedDate, selectedDriver);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbDrivers.SelectedIndex = 0;
            dtpServiceDate.Value = defaultDate;
            LoadAllReservations();
        }
        private void cmbDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // btnFilter_Click(sender, e);
        }

        private void dtpServiceDate_ValueChanged(object sender, EventArgs e)
        {
            // btnFilter_Click(sender, e);
        }
        private void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
