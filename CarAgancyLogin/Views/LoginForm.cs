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
            InitializeComponent();
        }

        private void btnLogin_Click_Click(object sender, EventArgs e)
        {
           
            string enteredPassword = txtPassword.Text;
            string hashedPassword = PasswordHasher.HashPassword(enteredPassword);

            
            UserController controller = new UserController();
            bool success = controller.Login(txtUsername.Text, hashedPassword, txtcombobox.Text);

            MessageBox.Show(success ? "Login successful!" : "Invalid credentials.");
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPasswordForm forgot = new ForgotPasswordForm();
            forgot.Show();
        }
    }
}
