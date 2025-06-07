using System;
using System.Windows.Forms;
using CarAgancyLogin.Controllers;
using CarAgancyLogin.Helpers;

namespace CarAgancyLogin.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent(); // مقداردهی اولیه کنترل‌های فرم
        }

        // رویداد کلیک روی دکمه ورود
        private void btnLogin_Click_Click(object sender, EventArgs e)
        {
            string enteredPassword = txtPassword.Text; // دریافت رمز واردشده
            string hashedPassword = PasswordHasher.HashPassword(enteredPassword);

            UserController controller = new UserController();
            bool success = controller.Login(txtUsername.Text, hashedPassword, txtcombobox.Text); // بررسی اطلاعات ورود

            if (success)
            {
                // بررسی نقش کاربر و هدایت به فرم مناسب
                if (txtcombobox.Text == "اپراتور")
                {
                    this.Hide();
                    OperatorForm opForm = new OperatorForm(txtUsername.Text); // ← فرم اپراتور
                    opForm.Show();
                }
                else if (txtcombobox.Text == "راننده")
                {
                    this.Hide();
                    DriverForm driverForm = new DriverForm(txtUsername.Text); // ← فرم راننده
                    driverForm.Show();
                }
                else if (txtcombobox.Text == "مدیر")
                {
                    this.Hide();
                    Manager managerForm = new Manager();  // ← فرم مدیر
                    managerForm.Show();
                }
                else if (txtcombobox.Text == "ادمین")
                {
                    this.Hide();
                    AdminForm adminForm = new AdminForm(); // ←  فرم ادمین 
                    adminForm.Show();
                }
                else
                {
                    MessageBox.Show("نقش ناشناخته. لطفاً دوباره تلاش کنید.");
                }
            }
            else
            {
                MessageBox.Show("نام کاربری یا رمز عبور اشتباه است.");
            }
        }

        // رویداد کلیک روی دکمه ثبت‌نام
        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            this.Hide(); // پنهان کردن فرم ورود
            RegisterForm registerForm = new RegisterForm(); // باز کردن فرم ثبت‌نام
            registerForm.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // مقداردهی اولیه در صورت نیاز
        }

        // رویداد کلیک روی دکمه فراموشی رمز عبور
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPasswordForm forgot = new ForgotPasswordForm();
            forgot.Show();
        }

        // بازگشت به فرم اصلی 
        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide(); // یا this.Close();
        }
    }
}
