using System;
using System.Windows.Forms;
using CarAgancyLogin.Controllers;
using CarAgancyLogin.Helpers; // برای هش کردن رمز عبور
using System.Drawing;

namespace CarAgancyLogin.Views
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent(); // مقداردهی اولیه فرم
        }

        // رویداد کلیک روی دکمه‌ی تغییر رمز عبور
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // دریافت مقادیر از ورودی کاربر
            string username = txtUsername.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirm.Text;

            // پاک‌سازی پیام‌های قبلی
            lblMessage.Text = "";
            lblMessage.Visible = false;

            // بررسی اینکه هیچ فیلدی خالی نباشد
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                lblMessage.Text = "لطفاً تمام فیلدها را پر کنید.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                return;
            }

            // بررسی فرمت رمز عبور: حداقل ۸ کاراکتر، شامل عدد و حرف
            if (!IsValidPassword(newPassword))
            {
                lblMessage.Text = "رمز عبور باید حداقل ۸ کاراکتر و شامل حروف و اعداد باشد.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                return;
            }

            // بررسی تطابق رمز عبور جدید با تکرار آن
            if (newPassword != confirmPassword)
            {
                lblMessage.Text = "رمزهای عبور یکسان نیستند.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                return;
            }

            // ایجاد شیء کنترلر برای دسترسی به کاربران
            UserController controller = new UserController();

            // بررسی اینکه نام کاربری در سیستم وجود داشته باشد
            if (!controller.IsUsernameTaken(username))
            {
                lblMessage.Text = "نام کاربری یافت نشد.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                return;
            }

            // هش کردن رمز عبور جدید برای ذخیره‌سازی امن
            string hashedPassword = PasswordHasher.HashPassword(newPassword);

            // تغییر رمز عبور در فایل یا پایگاه داده
            bool success = controller.ChangePassword(username, hashedPassword);

            // بررسی موفقیت عملیات
            if (success)
            {
                lblMessage.Text = "رمز عبور با موفقیت تغییر کرد.";
                lblMessage.ForeColor = Color.Green;
                lblMessage.Visible = true;
            }
            else
            {
                lblMessage.Text = "خطایی رخ داده است.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
            }
        }

        // متد کمکی برای بررسی اعتبار رمز عبور
        private bool IsValidPassword(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasLetter = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                    hasLetter = true;
                else if (char.IsDigit(c))
                    hasDigit = true;

                if (hasLetter && hasDigit)
                    return true;
            }

            return false;
        }

        // دکمه بازگشت به فرم ورود
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        // دکمه بازگشت دوم (احتمالاً نسخه تکراری)
        private void btnBackToLogin_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        // بازگشت به فرم ورود از طریق لینک
        private void linkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // پنهان کردن فرم فعلی
            LoginForm login = new LoginForm(); // ساخت فرم ورود
            login.Show(); // نمایش فرم ورود
        }

        // رویدادهای تغییر متن (در حال حاضر بدون منطق)
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txtConfirm_TextChanged(object sender, EventArgs e) { }
        private void txtUsername_TextChanged(object sender, EventArgs e) { }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
