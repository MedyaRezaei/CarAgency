using System;
using System.Windows.Forms;
using CarAgancyLogin.Models;
using CarAgancyLogin.Controllers;
using CarAgancyLogin.Helpers; 

namespace CarAgancyLogin.Views
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            
            string hashedPassword = PasswordHasher.HashPassword(txtPassword.Text);

            
            User user = new User
            {
                Username = txtUsername.Text,
                Password = hashedPassword,
                Phonenumber = txtPhonenumber.Text,
                Role = comboBoxRole.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text
            };

            
            UserController controller = new UserController();
            bool success = controller.Register(user);

            MessageBox.Show(success ? "Registration successful!" : "Failed to register.");
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnBackToLogin_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
