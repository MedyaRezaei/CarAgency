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
            this.loggedInUsername = username;
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

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerReservation registerPage = new CustomerReservation();
            LoadUserControl(registerPage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OperatorForm operatorForm = new OperatorForm(loggedInUsername); // استفاده مجدد از نام کاربری
            operatorForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AvailableDriversForm availableDrivers = new AvailableDriversForm();
            LoadUserControl(availableDrivers);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            EndTripUserControl endTripControl = new EndTripUserControl();
            endTripControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(endTripControl);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            // بارگذاری فرم پروفایل با نام کاربری
            ProfileForm profilePage = new ProfileForm(loggedInUsername);
            LoadUserControl(profilePage);
        }

        // توابع نقاشی پنل‌ها اگر نیاز بودند
        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void DailyRebtn_Click(object sender, EventArgs e)
        {
            ServiceReport profilePage = new ServiceReport(loggedInUsername);
            LoadUserControl(profilePage);

        }
    }
}
