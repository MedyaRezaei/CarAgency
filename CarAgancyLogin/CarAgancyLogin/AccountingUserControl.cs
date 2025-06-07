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
    public partial class AccountingUserControl : UserControl
    {
        public AccountingUserControl()
        {
            InitializeComponent();
            this.Load += AccountingUserControl_Load;

        }

        // بارگذاری اطلاعات رانندگان و محاسبه حقوق
        private void LoadDriversToGrid()
        {
            string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
            string query = "SELECT Username FROM Users WHERE Role = N'راننده'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                // افزودن ستون شماره
                table.Columns.Add("شماره", typeof(int));
                for (int i = 0; i < table.Rows.Count; i++)
                    table.Rows[i]["شماره"] = i + 1;
                table.Columns["شماره"].SetOrdinal(0);

                // افزودن ستون حقوق
                table.Columns.Add("حقوق", typeof(string));

                foreach (DataRow row in table.Rows)
                {
                    string username = row["Username"].ToString();
                    int serviceCount = GetCurrentMonthServiceCount(username); // تعداد سرویس‌ها در ماه جاری
                    int salary = serviceCount * 80000; // محاسبه حقوق (هر سرویس = ۸۰هزار)
                    row["حقوق"] = $"{salary:n0} تومان";
                }

                dataGridDrivers.DataSource = table;

                // تنظیم اندازه خودکار ستون‌ها
                dataGridDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // تنظیم عنوان ستون‌ها
                dataGridDrivers.Columns["Username"].HeaderText = "نام کاربری";
                dataGridDrivers.Columns["حقوق"].HeaderText = "حقوق";
            }
        }

        // کلیک روی هر ردیف: نمایش حقوق راننده در لیبل
        private void dataGridDrivers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string username = dataGridDrivers.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                int serviceCount = GetCurrentMonthServiceCount(username);
                int salary = serviceCount * 80000;
                lblDriverSalary.Text = $"حقوق راننده {username}: {salary:n0} تومان";
            }
        }

        // متد کمکی برای گرفتن تعداد سرویس‌های یک راننده در ماه جاری
        private int GetCurrentMonthServiceCount(string username)
        {
            string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
            string query = @"
        SELECT COUNT(*) 
        FROM Reservations 
        WHERE DriverUsername = @username
            AND MONTH(ReservationDate) = MONTH(GETDATE())
            AND YEAR(ReservationDate) = YEAR(GETDATE())";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridDrivers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // بازگشت به صفحه اصلی فرم Manager
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

        private void AccountingUserControl_Load(object sender, EventArgs e)
        {
            LoadDriversToGrid();
        }

    }
}
