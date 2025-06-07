using System;
using System.Windows.Forms;
using CarAgancyLogin.Views;

namespace CarAgancyLogin
{
    public partial class Driver : Form
    {
        private string loggedInDriverUsername;

        public Driver(string username)
        {
            InitializeComponent();
            loggedInDriverUsername = username;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // خالی مگر اینکه بخوای طراحی خاصی اعمال کنی
        }

        private void btnServiceHistory_Click(object sender, EventArgs e)
        {
            ServiceHistory historyControl = new ServiceHistory(loggedInDriverUsername);

            // اضافه کردن به فرم جاری (یا پنل خاصی که داری)
            this.Controls.Clear(); // یا اگر نمی‌خوای کل فرم پاک بشه، فقط پنل مربوطه رو پاک کن
            this.Controls.Add(historyControl);
            historyControl.Dock = DockStyle.Fill;
        }
    }
}