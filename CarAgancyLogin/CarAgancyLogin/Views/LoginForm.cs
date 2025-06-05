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
            string enteredPassword = txtPassword.Text;
            string hashedPassword = PasswordHasher.HashPassword(enteredPassword);

            UserController controller = new UserController();
            bool success = controller.Login(txtUsername.Text, hashedPassword, txtcombobox.Text);

            if (success)
            {
                // اگر نقش اپراتور باشد، فرم اپراتور را نمایش بده
                if (txtcombobox.Text == "اپراتور")
                {
                    this.Hide();
                    OperatorForm opForm = new OperatorForm(); // فرض بر این است که فرم اپراتور OperatorForm نام دارد
                    opForm.Show();
                }
                else
                {
                    // اگر نقش اپراتور نبود ولی ورود موفق بود، می‌توان فرم‌های دیگر باز کرد یا پیام داد
                    this.Hide();
                    MessageBox.Show("ورود موفق.");
                    // یا: فرم خاص دیگر باز شود
                }
            }
            else
            {
                MessageBox.Show("نام کاربری یا رمز عبور اشتباه است.");
            }
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
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
        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            // باز کردن فرم اصلی و بستن فرم لاگین
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide(); // یا this.Close();
        }

    }
}
