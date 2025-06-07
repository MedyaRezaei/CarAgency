using CarAgancyLogin.Views;
using System;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class OperatorForm : Form
    {
        private string loggedInUsername; // ذخیره نام کاربری وارد شده

        public OperatorForm(string username)
        {
            InitializeComponent();
            this.loggedInUsername = username; // مقداردهی نام کاربری
        }

        private void OperatorForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; // فرم تمام‌صفحه
        }

        private void LoadUserControl(UserControl uc)
        {
            panel1.Controls.Clear();         // حذف کنترل قبلی
            uc.Dock = DockStyle.Fill;        // پر کردن کامل پنل
            panel1.Controls.Add(uc);         // اضافه کردن کنترل جدید
        }

        // دکمه شماره 1: نمایش فرم ثبت رزرو مشتری
        private void button1_Click(object sender, EventArgs e)
        {
            CustomerReservation registerPage = new CustomerReservation();
            LoadUserControl(registerPage);
        }

        // دکمه شماره 2: بازگشت به فرم اصلی سیستم
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        // دکمه شماره 3: ریست کردن فرم اپراتور با نام کاربری فعلی
        private void button3_Click(object sender, EventArgs e)
        {
            OperatorForm operatorForm = new OperatorForm(loggedInUsername); // استفاده مجدد از نام کاربری
            operatorForm.Show();
            this.Hide();
        }

        // دکمه شماره 5: نمایش لیست راننده‌های در دسترس
        private void button5_Click(object sender, EventArgs e)
        {
            AvailableDriversForm availableDrivers = new AvailableDriversForm();
            LoadUserControl(availableDrivers);
        }

        // دکمه شماره 7: ثبت پایان سفر برای راننده
        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            EndTripUserControl endTripControl = new EndTripUserControl();
            endTripControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(endTripControl);
        }

        // دکمه پروفایل: نمایش پروفایل اپراتور
        private void btnProfile_Click(object sender, EventArgs e)
        {
            // بارگذاری فرم پروفایل با نام کاربری
            ProfileForm profilePage = new ProfileForm(loggedInUsername);
            LoadUserControl(profilePage);
        }

        // توابع نقاشی پنل‌ها اگر نیاز بودند
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        // دکمه گزارش روزانه: نمایش گزارش سرویس‌های روز
        private void DailyRebtn_Click(object sender, EventArgs e)
        {
            ServiceReport profilePage = new ServiceReport(loggedInUsername);
            LoadUserControl(profilePage);

        }
    }
}
