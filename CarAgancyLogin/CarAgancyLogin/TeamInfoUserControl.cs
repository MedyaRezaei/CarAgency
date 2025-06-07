using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class TeamInfoUserControl : UserControl
    {
        public TeamInfoUserControl()
        {
            // بارگذاری اولیه جداول رانندگان، ادمین‌ها، اپراتورها
            InitializeComponent();
            LoadDriversTable();
            LoadAdminsTable();
            LoadOperatorsTable();
        }

        // بارگذاری اطلاعات راننده‌ها
        private void LoadDriversTable()
        {
            string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
            string query = @"
        SELECT 
            u.Username AS 'نام کاربری',
            u.PhoneNumber AS 'شماره تلفن',
            u.Address AS 'آدرس',
            u.Email AS 'ایمیل',
            u.LicenseNumber AS 'شماره گواهینامه',
            v.Model AS 'مدل ماشین'
        FROM Users u
        LEFT JOIN Vehicles v ON u.Username = v.DriverUsername
        WHERE u.Role = N'راننده'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                // اضافه کردن ستون شناسه دستی
                table.Columns.Add("شناسه", typeof(int));
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i]["شناسه"] = i + 1;
                }

                // مرتب‌سازی ستون‌ها به ترتیب راست به چپ
                table.Columns["شناسه"].SetOrdinal(0); // راست‌ترین
                table.Columns["نام کاربری"].SetOrdinal(1);
                table.Columns["آدرس"].SetOrdinal(2);
                table.Columns["ایمیل"].SetOrdinal(3);
                table.Columns["شماره گواهینامه"].SetOrdinal(4);
                table.Columns["مدل ماشین"].SetOrdinal(5);
                table.Columns["شماره تلفن"].SetOrdinal(6); // آخرین ستون

                dataGridDrivers.DataSource = table;

                // تنظیمات راست‌چین
                dataGridDrivers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridDrivers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dataGridDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridDrivers.ReadOnly = true;
            }
        }


        // بارگذاری اطلاعات ادمین‌ها
        private void LoadAdminsTable()
        {
            string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
            string query = @"
        SELECT 
            Username AS 'نام کاربری',
            PhoneNumber AS 'شماره تلفن',
            Address AS 'آدرس',
            Email AS 'ایمیل'
        FROM Users
        WHERE Role = N'ادمین'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                // اضافه کردن ستون شناسه دستی
                table.Columns.Add("شناسه", typeof(int));
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i]["شناسه"] = i + 1;
                }

                // مرتب‌سازی ستون‌ها
                table.Columns["شناسه"].SetOrdinal(0); // راست‌ترین
                table.Columns["نام کاربری"].SetOrdinal(1);
                table.Columns["آدرس"].SetOrdinal(2);
                table.Columns["ایمیل"].SetOrdinal(3);
                table.Columns["شماره تلفن"].SetOrdinal(4); // آخرین

                dataGridAdmins.DataSource = table;

                // تنظیمات راست‌چین
                dataGridAdmins.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridAdmins.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dataGridAdmins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridAdmins.ReadOnly = true;
            }
        }


        // بارگذاری اطلاعات اپراتورها
        private void LoadOperatorsTable()
        {
            string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
            string query = @"
        SELECT 
            Username AS 'نام کاربری',
            PhoneNumber AS 'شماره تلفن',
            Address AS 'آدرس',
            Email AS 'ایمیل'
        FROM Users
        WHERE Role = N'اپراتور'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                // اضافه کردن ستون شناسه دستی
                table.Columns.Add("شناسه", typeof(int));
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i]["شناسه"] = i + 1;
                }

                // مرتب‌سازی ستون‌ها
                table.Columns["شناسه"].SetOrdinal(0); // راست‌ترین
                table.Columns["نام کاربری"].SetOrdinal(1);
                table.Columns["آدرس"].SetOrdinal(2);
                table.Columns["ایمیل"].SetOrdinal(3);
                table.Columns["شماره تلفن"].SetOrdinal(4); // آخرین

                dataGridOperators.DataSource = table;

                // تنظیمات راست‌چین
                dataGridOperators.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridOperators.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dataGridOperators.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridOperators.ReadOnly = true;
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void txtDateFilter_TextChanged(object sender, EventArgs e)
        {
        }
        private void btnDeleteDriver_Click(object sender, EventArgs e)
        {
            if (dataGridDrivers.SelectedRows.Count > 0)
            {
                string username = dataGridDrivers.SelectedRows[0].Cells["نام کاربری"].Value.ToString();
                string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
                string deleteQuery = "DELETE FROM Users WHERE Username = @username";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                LoadDriversTable();  // بروزرسانی جدول پس از حذف
            }
            else
            {
                MessageBox.Show("لطفاً یک ردیف را انتخاب کنید.");
            }
        }

        private void btnDeleteOperator_Click(object sender, EventArgs e)
        {
            if (dataGridOperators.SelectedRows.Count > 0)
            {
                string username = dataGridOperators.SelectedRows[0].Cells["نام کاربری"].Value.ToString();
                string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
                string deleteQuery = "DELETE FROM Users WHERE Username = @username";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                LoadOperatorsTable(); // بروزرسانی جدول اپراتورها
            }
            else
            {
                MessageBox.Show("لطفاً یک ردیف را انتخاب کنید.");
            }
        }

        private void btnDeleteAdmin_Click(object sender, EventArgs e)
        {
            if (dataGridAdmins.SelectedRows.Count > 0)
            {
                string username = dataGridAdmins.SelectedRows[0].Cells["نام کاربری"].Value.ToString();
                string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
                string deleteQuery = "DELETE FROM Users WHERE Username = @username";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                LoadAdminsTable(); // بروزرسانی جدول ادمین‌ها
            }
            else
            {
                MessageBox.Show("لطفاً یک ردیف را انتخاب کنید.");
            }
        }

        private void dataGridDrivers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dataGridOperators_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void btnClearFilterOperator_Click(object sender, EventArgs e)
        {
        }
        private void btnFilterOperator_Click(object sender, EventArgs e)
        {
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtSearchAdmin_Click(object sender, EventArgs e)
        {
        }
        // فیلتر جستجو اپراتورها
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchOperator.Text.Trim();

            (dataGridOperators.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("[نام کاربری] LIKE '%{0}%' OR [ایمیل] LIKE '%{0}%' OR [شماره تلفن] LIKE '%{0}%'", searchValue);
        }

        // فیلتر جستجو ادمین‌ها
        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            string searchValue = txtSearchAdmin.Text.Trim();

            (dataGridAdmins.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("[نام کاربری] LIKE '%{0}%' OR [ایمیل] LIKE '%{0}%' OR [شماره تلفن] LIKE '%{0}%'", searchValue);
        }

        // فیلتر جستجو راننده‌ها
        private void txtSearchDriver_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchDriver.Text.Trim();

            (dataGridDrivers.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("[نام کاربری] LIKE '%{0}%' OR [ایمیل] LIKE '%{0}%' OR [شماره تلفن] LIKE '%{0}%'", searchValue);
        }

        // بازگشت به صفحه اصلی 
        private void btnBackToHome_Click_Click(object sender, EventArgs e)
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

                // اگه متد گرد کردن public نیست از reflection استفاده می‌کنیم
                MethodInfo method = typeof(Manager).GetMethod("MakePanelRounded", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (method != null)
                {
                    method.Invoke(managerForm, new object[] { managerForm.MainPanel });
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

                // اگه متد گرد کردن public نیست از reflection استفاده می‌کنیم
                MethodInfo method = typeof(Manager).GetMethod("MakePanelRounded", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (method != null)
                {
                    method.Invoke(managerForm, new object[] { managerForm.MainPanel });
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

                // اگه متد گرد کردن public نیست از reflection استفاده می‌کنیم
                MethodInfo method = typeof(Manager).GetMethod("MakePanelRounded", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (method != null)
                {
                    method.Invoke(managerForm, new object[] { managerForm.MainPanel });
                }
            }
        }
    }
}
