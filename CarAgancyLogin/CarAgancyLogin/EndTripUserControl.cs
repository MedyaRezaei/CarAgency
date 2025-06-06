using System;
using System.Windows.Forms;
using CarAgancyLogin.Controllers;
using CarAgancyLogin.Models;
using System.Collections.Generic;

namespace CarAgancyLogin.Views
{
    public partial class EndTripUserControl : UserControl
    {
        private UserController userController = new UserController();

        public EndTripUserControl()
        {
            InitializeComponent();
            LoadUnavailableDrivers(); // بارگذاری رانندگان غیردردسترس در آغاز
        }

        private void LoadUnavailableDrivers()
        {
            List<User> drivers = userController.GetUnavailableDrivers();
            dgvBusyDrivers.DataSource = drivers;

            //// مخفی کردن ستون‌های حساس
            //dgvBusyDrivers.Columns["Password"]?.Visible = false;
            //dgvBusyDrivers.Columns["Role"]?.Visible = false;
            //dgvBusyDrivers.Columns["IsAvailable"]?.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvBusyDrivers.SelectedRows.Count > 0)
            {
                string username = dgvBusyDrivers.SelectedRows[0].Cells["Username"].Value.ToString();

                // به‌روزرسانی وضعیت در دسترس بودن
                userController.SetDriverAvailability(username, true);

                MessageBox.Show($"راننده '{username}' اکنون در دسترس است.", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // بازخوانی لیست پس از به‌روزرسانی
                LoadUnavailableDrivers();
            }
            else
            {
                MessageBox.Show("لطفاً یک راننده را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EndTrip_Load(object sender, EventArgs e)
        {
            // اگر خواستی هنگام Load کاری انجام بشه اینجا بنویس
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // کلیک روی label1
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // کلیک روی label2
        }

        private void dgvBusyDrivers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // کلیک روی سلول‌های دیتاگرید
        }
    }
}
