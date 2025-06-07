using System;
using System.Linq;
using System.Windows.Forms;
using CarAgancyLogin.Controllers;
using CarAgancyLogin.Helpers; // برای هش کردن رمز عبور
using System.Drawing;

namespace CarAgancyLogin.Views
{
    public partial class ForgotPasswordForm : Form
    {
        private string generatedCaptcha;

        public ForgotPasswordForm()
        {
            InitializeComponent();
            GenerateCaptcha();
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void GenerateCaptcha()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            generatedCaptcha = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            lblCaptchaText.Text = generatedCaptcha;
        }

        private void btnRefreshCaptcha_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirm.Text;
            string captchaInput = txtCaptchaAnswer.Text.Trim();

            lblMessage.Text = "";
            lblMessage.Visible = false;

            // بررسی اینکه همه فیلدها پر شده باشند
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword) ||
                string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(captchaInput))
            {
                lblMessage.Text = "لطفاً تمام فیلدها را پر کنید.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                return;
            }

            // بررسی تطابق کپچا
            if (captchaInput != generatedCaptcha)
            {
                lblMessage.Text = "کدامنیتی صحیح نیست. لطفاً مجدد تلاش کنید.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                GenerateCaptcha(); // تولید کپچا جدید در صورت اشتباه بودن
                return;
            }

            // اعتبارسنجی رمز عبور
            if (!IsValidPassword(newPassword))
            {
                lblMessage.Text = "رمز عبور باید حداقل ۸ کاراکتر و شامل حروف و اعداد باشد.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                return;
            }

            // بررسی تطابق رمز عبور با تکرار آن
            if (newPassword != confirmPassword)
            {
                lblMessage.Text = "رمزهای عبور یکسان نیستند.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                return;
            }

            UserController controller = new UserController();

            // بررسی وجود نام کاربری
            if (!controller.IsUsernameTaken(username))
            {
                lblMessage.Text = "نام کاربری یافت نشد.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                return;
            }

            // هش کردن و تغییر رمز عبور
            string hashedPassword = PasswordHasher.HashPassword(newPassword);
            bool success = controller.ChangePassword(username, hashedPassword);

            if (success)
            {
                lblMessage.Text = "رمز عبور با موفقیت تغییر کرد.";
                lblMessage.ForeColor = Color.Green;
                lblMessage.Visible = true;

                // پاک کردن تکست‌باکس‌ها
                txtUsername.Text = "";
                txtNewPassword.Text = "";
                txtConfirm.Text = "";
                txtCaptchaAnswer.Text = "";

                // تولید کپچا جدید
                GenerateCaptcha();
            }
            else
            {
                lblMessage.Text = "خطایی رخ داده است.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
            }
        }

        // بررسی صحت رمز عبور: حداقل 8 کاراکتر، شامل حروف و عدد
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

        private void btnBackToLogin_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void linkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        // رویدادهای اضافی (فعلاً بدون منطق)
        private void txtCaptchaAnswer_TextChanged(object sender, EventArgs e) { }
        private void lblCaptchaText_Click(object sender, EventArgs e) { }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
