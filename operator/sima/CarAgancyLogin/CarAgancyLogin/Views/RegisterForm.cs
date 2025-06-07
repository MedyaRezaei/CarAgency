using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CarAgancyLogin.Models;
using CarAgancyLogin.Controllers;
using CarAgancyLogin.Helpers;
using CarAgancyLogin;

namespace CarAgancyLogin.Views
{
    public partial class RegisterForm : Form
    {
        private bool isDriver = false; // اضافه کردن این متغیر برای تشخیص نقش راننده

        public RegisterForm()
        {
            InitializeComponent();
            comboBoxRole.SelectedIndexChanged += comboBoxRole_SelectedIndexChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            bool allFieldsFilled = true;

            // پاک‌سازی پیام‌های خطا
            lblUsernameError.Text = "";
            lblPasswordError.Text = "";
            lblConfirmPasswordError.Text = "";
            lblPhonenumberError.Text = "";
            lblRoleError.Text = "";
            lblEmailError.Text = "";
            lblAddressError.Text = "";

            // بررسی پر بودن فیلدها
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

            if (comboBoxRole.Text == "راننده" && string.IsNullOrWhiteSpace(txtLicenseNumber.Text))
            {
                MessageBox.Show("لطفاً شماره گواهینامه را وارد کنید.");
                allFieldsFilled = false;
            }

            if (!allFieldsFilled) return;

            // اعتبارسنجی رمز عبور
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

            UserController controller = new UserController();

            if (controller.IsUsernameTaken(txtUsername.Text))
            {
                lblUsernameError.Text = "نام کاربری تکراری است";
                isValid = false;
            }

            if (controller.IsEmailTaken(txtEmail.Text))
            {
                lblEmailError.Text = "این ایمیل قبلاً ثبت شده است";
                isValid = false;
            }

            if (!isValid) return;

            string hashedPassword = PasswordHasher.HashPassword(txtPassword.Text);

            User user = new User
            {
                Username = txtUsername.Text,
                Password = hashedPassword,
                Phonenumber = txtPhonenumber.Text,
                Role = comboBoxRole.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                LicenseNumber = comboBoxRole.Text == "راننده" ? txtLicenseNumber.Text : null
            };

            bool success = controller.Register(user);

            if (success)
            {
                if (isDriver)
                {
                    // اگر نقش راننده بود، به فرم ثبت وسیله نقلیه برو
                    RegisterVehicles vehicleForm = new RegisterVehicles(user.Username);
                    vehicleForm.FormClosed += (s, args) => this.Close();
                    this.Hide();
                    vehicleForm.Show();
                }
                else if (user.Role == "مدیر")
                {
                    MessageBox.Show("ثبت نام با موفقیت انجام شد!");
                }
                else if (user.Role == "ادمین")
                {
                    MessageBox.Show("ثبت نام با موفقیت انجام شد!");
                }
                
            }
            else
            {
                MessageBox.Show("ثبت نام ناموفق بود.");
            }

        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRole.SelectedItem?.ToString() == "راننده")
            {
                txtLicenseNumber.Visible = true;
                lblLicenseNumber.Visible = true;
                isDriver = true; // نقش راننده انتخاب شده
                btnRegister.Text = "ادامه"; // تغییر متن دکمه
            }
            else
            {
                txtLicenseNumber.Visible = false;
                lblLicenseNumber.Visible = false;
                isDriver = false;
                btnRegister.Text = "ثبت نام"; // بازگرداندن متن دکمه به حالت عادی
            }
        }
    }
}
