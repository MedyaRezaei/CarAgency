using System;
using System.Windows.Forms;
using CarAgancyLogin.Controllers;
using CarAgancyLogin.Helpers;
using CarAgancyLogin.Models;

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
            string hashedPassword = PasswordHasher.HashPassword(enteredPassword); // هش کردن رمز

            UserController controller = new UserController();
            User user = controller.GetUserByUsernameAndPassword(txtUsername.Text, hashedPassword); // گرفتن کاربر

            if (user != null)
            {
                string role = user.Role; // دریافت نقش از دیتابیس

                this.Hide();

                if (role == "اپراتور")
                {
                    OperatorForm opForm = new OperatorForm(user.Username); // ← فرم اپراتور
                    opForm.Show();
                }
                else if (role == "راننده")
                {
                    DriverForm driverForm = new DriverForm(user.Username); // ← فرم راننده
                    driverForm.Show();
                }
                else if (role == "مدیر")
                {
                    Manager managerForm = new Manager(); // ← فرم مدیر
                    managerForm.Show();
                }
                else if (role == "ادمین")
                {
                    AdminForm adminForm = new AdminForm(); // ← فرم ادمین
                    adminForm.Show();
                }
                else
                {
                    MessageBox.Show("نقش کاربر تعریف نشده است.");
                    this.Show(); // نمایش مجدد فرم ورود در صورت خطا
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
