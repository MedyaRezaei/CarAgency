using System;
using System.Text.RegularExpressions;
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
            bool isValid = true;
            bool allFieldsFilled = true;

            // Reset error messages
            lblUsernameError.Text = "";
            lblPasswordError.Text = "";
            lblConfirmPasswordError.Text = "";
            lblPhonenumberError.Text = "";
            lblRoleError.Text = "";
            lblEmailError.Text = "";
            lblAddressError.Text = "";

            // Step 1: Check for empty fields
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                lblUsernameError.Text = "کادر خالی است";
                allFieldsFilled = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblPasswordError.Text = "کادر خالی است";
                allFieldsFilled = false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                lblConfirmPasswordError.Text = "کادر خالی است";
                allFieldsFilled = false;
            }

            if (string.IsNullOrWhiteSpace(txtPhonenumber.Text))
            {
                lblPhonenumberError.Text = "کادر خالی است";
                allFieldsFilled = false;
            }

            if (string.IsNullOrWhiteSpace(comboBoxRole.Text))
            {
                lblRoleError.Text = "کادر خالی است";
                allFieldsFilled = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblEmailError.Text = "کادر خالی است";
                allFieldsFilled = false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                lblAddressError.Text = "کادر خالی است";
                allFieldsFilled = false;
            }

            // Stop if any field is empty
            if (!allFieldsFilled)
            {
                return;
            }

            // Step 2: Validation rules
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblConfirmPasswordError.Text = "رمزها مطابقت ندارند";
                isValid = false;
            }

            if (!Regex.IsMatch(txtPassword.Text, @"^(?=.*[A-Za-z])(?=.*\d).{8,}$"))
            {
                lblPasswordError.Text = "رمز عبور باید حداقل ۸ کاراکتر و شامل عدد و حرف باشد";
                isValid = false;
            }

            if (!Regex.IsMatch(txtPhonenumber.Text, @"^\d{11}$"))
            {
                lblPhonenumberError.Text = "شماره تلفن باید ۱۱ رقم باشد";
                isValid = false;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@(gmail\.com|yahoo\.com)$"))
            {
                lblEmailError.Text = "ایمیل باید معتبر باشد و با @gmail.com یا @yahoo.com تمام شود";
                isValid = false;
            }

            // Step 3: Check for duplicate username
            UserController controller = new UserController();
            if (controller.IsUsernameTaken(txtUsername.Text))
            {
                lblUsernameError.Text = "نام کاربری تکراری است";
                isValid = false;
            }

            // Stop if any validation failed
            if (!isValid)
            {
                return;
            }

            // Hash the password
            string hashedPassword = PasswordHasher.HashPassword(txtPassword.Text);

            // Create user object
            User user = new User
            {
                Username = txtUsername.Text,
                Password = hashedPassword,
                Phonenumber = txtPhonenumber.Text,
                Role = comboBoxRole.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text
            };

            // Register user
            bool success = controller.Register(user);

            MessageBox.Show(success ? "ثبت نام با موفقیت انجام شد!" : "ثبت نام ناموفق بود.");
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void btnBackToLogin_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
