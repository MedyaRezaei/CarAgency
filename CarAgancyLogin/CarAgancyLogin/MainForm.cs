using CarAgancyLogin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; // تمام صفحه)
            this.TopMost = true;    // نمایش در بالاترین لایه (اختیاری)
            HomeUserControl home = new HomeUserControl();
            LoadUserControl(home);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panelMainContent.Dock = DockStyle.Fill;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Dock = DockStyle.Top;
          

        }

        private void button5_Click(object sender, EventArgs e)
        {


          
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        

        

        private void button1_Click(object sender, EventArgs e)
        {
        
            AboutForm aboutPage = new AboutForm();  // ساخت نمونه از کنترل

            LoadUserControl(aboutPage);             // نمایش در پنل
        }

        
        private void LoadUserControl(UserControl uc)
        {
            panelMainContent.Controls.Clear();      // حذف کنترل‌های قبلی
            uc.Dock = DockStyle.Fill;               // پر کردن پنل
            panelMainContent.Controls.Add(uc);      // اضافه کردن کنترل جدید
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            ContactForm contactPage = new ContactForm();  // ساخت نمونه از کنترل تماس با ما
            LoadUserControl(contactPage);                 // نمایش در پنل
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            FeedbackForm feedbackPage = new FeedbackForm();  // ساخت نمونه از کنترل بازخورد
            LoadUserControl(feedbackPage);                   // نمایش در پنل
        }

        private void button4_Click(object sender, EventArgs e)
        {


          
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); // اول فرم جدید رو باز می‌کنیم
            this.Hide();      // بعد فرم فعلی رو پنهان می‌کنیم
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
         
            HomeUserControl home = new HomeUserControl();
            LoadUserControl(home);
        }

    }
}






