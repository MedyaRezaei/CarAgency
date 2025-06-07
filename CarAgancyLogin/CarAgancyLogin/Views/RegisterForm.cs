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
        // متغیر برای تشخیص اینکه نقش انتخابی "راننده" است یا خیر
        private bool isDriver = false;

        public RegisterForm()
        {
            InitializeComponent();
            // ثبت رویداد تغییر نقش در کامبوباکس
            comboBoxRole.SelectedIndexChanged += comboBoxRole_SelectedIndexChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            bool allFieldsFilled = true;

            // پاک کردن پیام‌های خطای قبلی برای هر فیلد
            lblUsernameError.Text = "";
            lblPasswordError.Text = "";
            lblConfirmPasswordError.Text = "";
            lblPhonenumberError.Text = "";
            lblRoleError.Text = "";
            lblEmailError.Text = "";
            lblAddressError.Text = "";
            lblLicenseNumberError.Text = "";

            // بررسی اینکه فیلدها خالی نباشند
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) { lblUsernameError.Text = "کادر خالی است"; allFieldsFilled = false; }
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) { lblPasswordError.Text = "کادر خالی است"; allFieldsFilled = false; }
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text)) { lblConfirmPasswordError.Text = "کادر خالی است"; allFieldsFilled = false; }
            if (string.IsNullOrWhiteSpace(txtPhonenumber.Text)) { lblPhonenumberError.Text = "کادر خالی است"; allFieldsFilled = false; }
            if (string.IsNullOrWhiteSpace(comboBoxRole.Text)) { lblRoleError.Text = "کادر خالی است"; allFieldsFilled = false; }
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { lblEmailError.Text = "کادر خالی است"; allFieldsFilled = false; }
            if (string.IsNullOrWhiteSpace(txtAddress.Text)) { lblAddressError.Text = "کادر خالی است"; allFieldsFilled = false; }

            // بررسی اینکه راننده حتماً شماره گواهینامه وارد کرده باشد
            if (comboBoxRole.Text == "راننده" && string.IsNullOrWhiteSpace(txtLicenseNumber.Text))
            {
                lblLicenseNumberError.Text = "شماره گواهینامه الزامی است";
                allFieldsFilled = false;
            }

            if (!allFieldsFilled) return;

            // بررسی مطابقت رمز عبور و تکرار آن
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblConfirmPasswordError.Text = "رمزها مطابقت ندارند";
                isValid = false;
            }

            // بررسی پیچیدگی رمز عبور: حداقل ۸ کاراکتر، شامل حرف و عدد
            if (!Regex.IsMatch(txtPassword.Text, @"^(?=.*[A-Za-z])(?=.*\d).{8,}$"))
            {
                lblPasswordError.Text = "رمز عبور باید حداقل ۸ کاراکتر و شامل عدد و حرف باشد";
                isValid = false;
            }

            // بررسی قالب شماره تلفن: دقیقاً ۱۱ رقم
            if (!Regex.IsMatch(txtPhonenumber.Text, @"^\d{11}$"))
            {
                lblPhonenumberError.Text = "شماره تلفن باید ۱۱ رقم باشد";
                isValid = false;
            }

            // بررسی قالب ایمیل: باید با @gmail.com یا @yahoo.com تمام شود
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@(gmail\.com|yahoo\.com)$"))
            {
                lblEmailError.Text = "ایمیل باید معتبر باشد و با @gmail.com یا @yahoo.com تمام شود";
                isValid = false;
            }

            // اعتبارسنجی شماره گواهینامه برای راننده: بین ۸ تا ۱۰ رقم
            if (comboBoxRole.Text == "راننده")
            {
                if (!Regex.IsMatch(txtLicenseNumber.Text, @"^\d{8,10}$"))
                {
                    lblLicenseNumberError.Text = "شماره گواهینامه باید ۸ تا ۱۰ رقم باشد";
                    isValid = false;
                }
            }

            // بررسی تکراری نبودن نام کاربری، ایمیل و شماره تلفن
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

            if (controller.IsPhoneNumberTaken(txtPhonenumber.Text))
            {
                lblPhonenumberError.Text = "شماره تلفن تکراری است";
                isValid = false;
            }

            if (!isValid) return;

            // هش کردن رمز عبور
            string hashedPassword = PasswordHasher.HashPassword(txtPassword.Text);

            // ساخت شیء کاربر برای ثبت در پایگاه داده
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

            // ثبت کاربر در دیتابیس
            bool success = controller.Register(user);

            if (success)
            {
                // اگر نقش کاربر راننده باشد، فرم ثبت وسیله نقلیه را نمایش بده
                if (isDriver)
                {
                    RegisterVehicles vehicleForm = new RegisterVehicles(user.Username);
                    vehicleForm.FormClosed += (s, args) => this.Close();
                    this.Hide();
                    vehicleForm.Show();
                }
                // اگر نقش اپراتور، ادمین یا مدیر بود، وارد MainForm شود
                else if (user.Role == "اپراتور" || user.Role == "ادمین" || user.Role == "مدیر")
                {
                    MainForm mainForm = new MainForm();
                    mainForm.FormClosed += (s, args) => this.Close();
                    this.Hide();
                    mainForm.Show();
                }
                // در غیر این صورت پیام موفقیت و پاکسازی فیلدها
                else
                {
                    MessageBox.Show("ثبت نام با موفقیت انجام شد!");
                    ClearAllFields();
                }
            }

        }

        // متد برای پاکسازی تمام فیلدهای فرم پس از ثبت موفق
        private void ClearAllFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtPhonenumber.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtLicenseNumber.Text = "";
            comboBoxRole.SelectedIndex = -1;
            txtLicenseNumber.ReadOnly = false;
        }

        // دکمه بازگشت به فرم اصلی
        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        // زمانی که نقش کاربر تغییر کند (راننده یا سایر نقش‌ها)
        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRole.SelectedItem?.ToString() == "راننده")
            {
                txtLicenseNumber.ReadOnly = false;
                txtLicenseNumber.Visible = true;
                lblLicenseNumber.Visible = true;
                isDriver = true;
                btnRegister.Text = "ادامه";
            }
            else
            {
                txtLicenseNumber.ReadOnly = true;
                txtLicenseNumber.Text = "";
                txtLicenseNumber.Visible = true;
                lblLicenseNumber.Visible = true;
                isDriver = false;
                btnRegister.Text = "ثبت نام";
            }
        }
    }
}
