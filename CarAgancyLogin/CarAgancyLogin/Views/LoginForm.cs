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
            InitializeComponent();
        }

        private void btnLogin_Click_Click(object sender, EventArgs e)
        {
            string enteredPassword = txtPassword.Text;
            string hashedPassword = PasswordHasher.HashPassword(enteredPassword);

            UserController controller = new UserController();
            User user = controller.GetUserByUsernameAndPassword(txtUsername.Text, hashedPassword);

            if (user != null)
            {
                string role = user.Role;

                if (role == "اپراتور")
                {
                    this.Hide();
                    OperatorForm opForm = new OperatorForm(user.Username);
                    opForm.Show();
                }
                else if (role == "راننده")
                {
                    this.Hide();
                    DriverForm driverForm = new DriverForm(user.Username);
                    driverForm.Show();
                }
                else
                {
                    MessageBox.Show("نقش کاربر تعریف نشده است.");
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
            this.Hide();
            ForgotPasswordForm forgot = new ForgotPasswordForm();
            forgot.Show();
        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide(); // یا this.Close();
        }
    }
}
