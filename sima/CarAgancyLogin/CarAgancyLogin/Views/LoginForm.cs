using System;
using System.Windows.Forms;
using CarAgancyLogin.Controllers;
using CarAgancyLogin.Helpers; // برای هش کردن رمز عبور

namespace CarAgancyLogin.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_Click(object sender, EventArgs e)
        {
            // هش کردن رمز عبور وارد شده
            string enteredPassword = txtPassword.Text;
            string hashedPassword = PasswordHasher.HashPassword(enteredPassword);

            // بررسی ورود کاربر با استفاده از کنترلر
            UserController controller = new UserController();
            bool success = controller.Login(txtUsername.Text, hashedPassword, txtcombobox.Text);

            MessageBox.Show(success ? "ورود موفقیت‌آمیز بود!" : "نام کاربری یا رمز عبور اشتباه است.");
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            // انتقال به فرم ثبت‌نام
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // مقداردهی اولیه در صورت نیاز
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            // انتقال به فرم فراموشی رمز عبور
            this.Hide();
            ForgotPasswordForm forgot = new ForgotPasswordForm();
            forgot.Show();
        }
    }
}
