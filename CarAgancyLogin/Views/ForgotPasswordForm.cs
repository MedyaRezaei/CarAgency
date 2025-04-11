using System;
using System.Windows.Forms;
using CarAgancyLogin.Controllers;
using CarAgancyLogin.Helpers; // For PasswordHasher

namespace CarAgancyLogin.Views
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirm.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string hashedPassword = PasswordHasher.HashPassword(newPassword);

            UserController controller = new UserController();
            bool success = controller.ChangePassword(username, hashedPassword);

            MessageBox.Show(success ? "Password changed successfully!" : "Failed to update password. Username not found.");
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
