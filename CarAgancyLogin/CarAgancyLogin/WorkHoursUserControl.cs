using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class WorkHoursUserControl : UserControl
    {
        public WorkHoursUserControl()
        {
            InitializeComponent();
            btnBackToHome.Click += btnBackToHome_Click;
            this.Load += WorkHoursUserControl_Load;
            dataGridDriversList.CellClick += dataGridDriversList_CellClick;
        }

        private void WorkHoursUserControl_Load(object sender, EventArgs e)
        {
            LoadDrivers(); // بارگذاری لیست رانندگان
        }
        private void LoadDrivers()
        {
            string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
            // کوئری انتخاب رانند‌ه‌ها
            string query = "SELECT Username FROM Users WHERE Role = N'راننده'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable table = new DataTable();
                adapter.Fill(table); // پر کردن جدول
                // اضافه کردن ستون شماره دستی
                table.Columns.Add("شماره", typeof(int));
                for (int i = 0; i < table.Rows.Count; i++)
                    table.Rows[i]["شماره"] = i + 1;
                table.Columns["شماره"].SetOrdinal(0); // جابه‌جایی ستون شماره به اول

                dataGridDriversList.DataSource = table;
                dataGridDriversList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridDriversList.Columns["Username"].HeaderText = "نام کاربری";

                // راست‌چین کردن ستون‌ها
                foreach (DataGridViewColumn col in dataGridDriversList.Columns)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void dataGridDriversList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // اگر ردیف معتبر باشد
            {
                // گرفتن نام کاربری راننده انتخاب‌شده
                string username = dataGridDriversList.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                // محاسبه ساعت کاری راننده
                int hours = CalculateDriverHours(username);
                // نمایش نتیجه در لیبل
                lblDriverHoursResult.Text = $"ساعت کاری راننده {username}: {hours} ساعت";
            }
        }

        private int CalculateDriverHours(string username) // متد محاسبه تعداد ساعت کاری راننده
        {
            string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
            // کوئری محاسبه تعداد رزرو در ماه جاری برای راننده
            string query = @" 
            SELECT COUNT(*) 
            FROM Reservations 
            WHERE DriverUsername = @username
            AND MONTH(ReservationDate) = MONTH(GETDATE())
            AND YEAR(ReservationDate) = YEAR(GETDATE())";

            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                conn.Open();
                count = (int)cmd.ExecuteScalar();
                conn.Close();
            }

            // فرض: هر سرویس معادل 1 ساعت کاری
            return count;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            Manager managerForm = this.FindForm() as Manager;
            if (managerForm != null)
            {
                managerForm.MainPanel.Controls.Clear();
                managerForm.MainPanel.Controls.Add(managerForm.WelcomeLabel);
                managerForm.MainPanel.Controls.Add(managerForm.HomeImage);
                managerForm.HomeImage.Dock = DockStyle.Fill;
                managerForm.WelcomeLabel.Visible = true;
                managerForm.HomeImage.Visible = true;

                // اعمال شکل هلالی به پنل
                MethodInfo method = typeof(Manager).GetMethod("MakePanelRounded", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (method != null)
                {
                    method.Invoke(managerForm, new object[] { managerForm.MainPanel });
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click_1(object sender, EventArgs e)
        {
        }
    }
}
