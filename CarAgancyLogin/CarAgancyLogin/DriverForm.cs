using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CarAgancyLogin
{
    public partial class DriverForm : Form
    {
        private string loggedInUsername; // ذخیره نام کاربری راننده لاگین شده
        public DriverForm(string username) // سازنده فرم راننده، دریافت نام کاربری برای نمایش اطلاعات مرتبط
        {
            InitializeComponent(); // مقداردهی اولیه کنترل‌های فرم
            this.loggedInUsername = username; // ذخیره نام کاربری
        }

        private void DriverForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;  // تمام صفحه کردن فرم برای نمایش بهتر
        }
        private void LoadUserControl(UserControl uc) // متدی برای بارگذاری فرم‌های کاربری در پنل اصلی (panel1)
        {
            panel1.Controls.Clear(); // پاک‌کردن کنترل‌های قبلی
            uc.Dock = DockStyle.Fill; // پر کردن فضای پنل
            panel1.Controls.Add(uc); // اضافه کردن کنترل جدید
        }

        private void button1_Click(object sender, EventArgs e) // دکمه‌ی نمایش تاریخچه فعالیت‌های راننده
        {
            // ساخت و بارگذاری فرم تاریخچه فعالیت‌ها
            Userhistory registerPage = new Userhistory(loggedInUsername);
            LoadUserControl(registerPage);
        }

        private void btnProfile_Click(object sender, EventArgs e) // ساخت و بارگذاری فرم پروفایل راننده
        {
            ProfileForm registerPage = new ProfileForm(loggedInUsername);
            LoadUserControl(registerPage);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ساخت نمونه جدید از فرم راننده با همان نام کاربری
            DriverForm driverForm = new DriverForm(loggedInUsername); 
            driverForm.Show(); // نمایش فرم جدید
            this.Hide(); // پنهان کردن فرم فعلی
        }

        private void button2_Click(object sender, EventArgs e)  // دکمه‌ی خروج به صفحه اصلی 
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}
