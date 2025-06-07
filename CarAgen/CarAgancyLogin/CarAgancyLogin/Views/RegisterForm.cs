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
            InitializeComponent(); // مقداردهی اولیه کامپوننت‌ها
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;           // برای بررسی صحت تمام فیلدها
            bool allFieldsFilled = true;   // برای بررسی پر بودن همه فیلدها

            // پاک کردن پیام‌های خطا
            lblUsernameError.Text = "";
            lblPasswordError.Text = "";
            lblConfirmPasswordError.Text = "";
            lblPhonenumberError.Text = "";
            lblRoleError.Text = "";
            lblEmailError.Text = "";
            lblAddressError.Text = "";

            // مرحله اول: بررسی پر بودن فیلدها
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

            // در صورت خالی بودن هر کادر، عملیات ادامه نمی‌یابد
            if (!allFieldsFilled)
            {
                return;
            }

            // مرحله دوم: اعتبارسنجی فیلدها

            // بررسی مطابقت رمز عبور و تکرار آن
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblConfirmPasswordError.Text = "رمزها مطابقت ندارند";
                isValid = false;
            }

            // بررسی حداقل ۸ کاراکتر بودن رمز و شامل بودن حرف و عدد
            if (!Regex.IsMatch(txtPassword.Text, @"^(?=.*[A-Za-z])(?=.*\d).{8,}$"))
            {
                lblPasswordError.Text = "رمز عبور باید حداقل ۸ کاراکتر و شامل عدد و حرف باشد";
                isValid = false;
            }

            // بررسی صحیح بودن شماره تلفن (۱۱ رقم)
            if (!Regex.IsMatch(txtPhonenumber.Text, @"^\d{11}$"))
            {
                lblPhonenumberError.Text = "شماره تلفن باید ۱۱ رقم باشد";
                isValid = false;
            }

            // بررسی فرمت صحیح ایمیل و پایان یافتن با @gmail.com یا @yahoo.com
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@(gmail\.com|yahoo\.com)$"))
            {
                lblEmailError.Text = "ایمیل باید معتبر باشد و با @gmail.com یا @yahoo.com تمام شود";
                isValid = false;
            }

            // مرحله سوم: بررسی تکراری نبودن نام کاربری و ایمیل
            UserController controller = new UserController();

            if (controller.IsUsernameTaken(txtUsername.Text))
            {
                lblUsernameError.Text = "نام کاربری تکراری است";
                isValid = false;
            }

            // ✅ بررسی تکراری بودن ایمیل
            if (controller.IsEmailTaken(txtEmail.Text))
            {
                lblEmailError.Text = "این ایمیل قبلاً ثبت شده است";
                isValid = false;
            }


            // در صورت عدم اعتبار داده‌ها، عملیات ثبت متوقف می‌شود
            if (!isValid)
            {
                return;
            }

            // هش کردن رمز عبور قبل از ذخیره‌سازی
            string hashedPassword = PasswordHasher.HashPassword(txtPassword.Text);

            // ایجاد شیء کاربر با اطلاعات وارد شده
            User user = new User
            {
                Username = txtUsername.Text,
                Password = hashedPassword,
                Phonenumber = txtPhonenumber.Text,
                Role = comboBoxRole.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text
            };

            // تلاش برای ثبت‌نام کاربر
            bool success = controller.Register(user);

            // نمایش پیام نتیجه ثبت‌نام
            MessageBox.Show(success ? "ثبت نام با موفقیت انجام شد!" : "ثبت نام ناموفق بود.");
        }

        // رویداد بازگشت به فرم ورود
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        // نسخه‌ی دوم رویداد بازگشت به فرم ورود (تکراری و قابل حذف)
        private void btnBackToLogin_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
