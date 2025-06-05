using System.Windows.Forms;
using System.Drawing;
using System;

namespace CarAgancyLogin.Views
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;


        // متد پاک‌سازی منابع در صورت نیاز
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // آزادسازی منابع گرافیکی
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {


            this.cmbVehicleType = new System.Windows.Forms.ComboBox();
            this.lblVehicleType = new System.Windows.Forms.Label();

            // تعریف پنل راست که دارای رنگ و متن خوش‌آمدگویی است
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label(); // عنوان خوش آمد
            this.lblSubtitle = new System.Windows.Forms.Label(); // زیر عنوان خوش آمد

            // تعریف تکست‌باکس‌ها و لیبل‌های مربوط به نام کاربری
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUsernameError = new System.Windows.Forms.Label(); // پیام خطا برای نام کاربری

            // تعریف رمز عبور و پیام خطای آن
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPasswordError = new System.Windows.Forms.Label();

            // تعریف تکرار رمز عبور و خطای آن
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblConfirmPasswordError = new System.Windows.Forms.Label();

            // تعریف شماره تلفن و خطای آن
            this.txtPhonenumber = new System.Windows.Forms.TextBox();
            this.lblPhonenumber = new System.Windows.Forms.Label();
            this.lblPhonenumberError = new System.Windows.Forms.Label();

            // تعریف نقش و پیام خطای آن
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblRoleError = new System.Windows.Forms.Label();




            // تعریف آدرس
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();

            // تعریف ایمیل و خطای آن
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEmailError = new System.Windows.Forms.Label();

            // دکمه‌های ثبت‌نام و بازگشت
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnBackToLogin = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // تنظیمات پنل سمت راست با رنگ خاص
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelRight.BackColor = System.Drawing.ColorTranslator.FromHtml("#4ecdc4");
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Width = 550;

            // افزودن تصویر به پنل رنگی سمت راست
            PictureBox picture = new PictureBox();
            picture.Image = Image.FromFile("evaluation.png"); // بارگذاری تصویر
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Size = new System.Drawing.Size(150, 150);
            picture.Location = new System.Drawing.Point((panelRight.Width - 150) / 2, 300); // موقعیت تصویر

            panelRight.Controls.Add(picture); // افزودن تصویر به پنل

            // لیبل خوش آمدگویی
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblWelcome.Text = "به صفحه ی ثبت نام خوش آمدید";
            this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWelcome.Size = new System.Drawing.Size(500, 40);
            this.lblWelcome.Location = new System.Drawing.Point(25, 180);

            // زیر عنوان
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblSubtitle.Text = "برای ایجاد حساب کاربری اطلاعات خود را وارد کنید";
            this.lblSubtitle.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitle.Size = new System.Drawing.Size(500, 30);
            this.lblSubtitle.Location = new System.Drawing.Point(25, 230);

            // افزودن لیبل‌ها به پنل سمت راست
            this.panelRight.Controls.Add(this.lblWelcome);
            this.panelRight.Controls.Add(this.lblSubtitle);

            // تعریف فونت فارسی و رنگ خطا برای اجزای فرم
            System.Drawing.Font persianFont = new System.Drawing.Font("Tahoma", 10);
            System.Drawing.Color errorColor = System.Drawing.Color.Red;
            int formLeft = 30;
            int formTop = 30;
            int spacing = 70;

            // شروع طراحی فیلدها - ابتدا نام کاربری
            this.lblUsername.Text = "نام کاربری:";
            this.lblUsername.Location = new System.Drawing.Point(formLeft, formTop);
            this.lblUsername.Size = new System.Drawing.Size(300, 20);
            this.lblUsername.Font = persianFont;

            this.txtUsername.Location = new System.Drawing.Point(formLeft, formTop + 25);
            this.txtUsername.Size = new System.Drawing.Size(300, 25);
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.lblUsernameError.ForeColor = errorColor;
            this.lblUsernameError.Location = new System.Drawing.Point(formLeft, formTop + 50);
            this.lblUsernameError.Size = new System.Drawing.Size(300, 20);

            formTop += spacing;

            // فیلد رمز عبور
            this.lblPassword.Text = "رمز عبور:";
            this.lblPassword.Location = new System.Drawing.Point(formLeft, formTop);
            this.lblPassword.Size = new System.Drawing.Size(300, 20);
            this.lblPassword.Font = persianFont;

            this.txtPassword.Location = new System.Drawing.Point(formLeft, formTop + 25);
            this.txtPassword.Size = new System.Drawing.Size(300, 25);
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.lblPasswordError.ForeColor = errorColor;
            this.lblPasswordError.Location = new System.Drawing.Point(formLeft, formTop + 50);
            this.lblPasswordError.Size = new System.Drawing.Size(300, 20);

            formTop += spacing;

            // فیلد تکرار رمز عبور
            this.lblConfirmPassword.Text = "تکرار رمز عبور:";
            this.lblConfirmPassword.Location = new System.Drawing.Point(formLeft, formTop);
            this.lblConfirmPassword.Size = new System.Drawing.Size(300, 20);
            this.lblConfirmPassword.Font = persianFont;

            this.txtConfirmPassword.Location = new System.Drawing.Point(formLeft, formTop + 25);
            this.txtConfirmPassword.Size = new System.Drawing.Size(300, 25);
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.lblConfirmPasswordError.ForeColor = errorColor;
            this.lblConfirmPasswordError.Location = new System.Drawing.Point(formLeft, formTop + 50);
            this.lblConfirmPasswordError.Size = new System.Drawing.Size(300, 20);

            formTop += spacing;

            // فیلد شماره تلفن
            this.lblPhonenumber.Text = "شماره تلفن:";
            this.lblPhonenumber.Location = new System.Drawing.Point(formLeft, formTop);
            this.lblPhonenumber.Size = new System.Drawing.Size(300, 20);
            this.lblPhonenumber.Font = persianFont;

            this.txtPhonenumber.Location = new System.Drawing.Point(formLeft, formTop + 25);
            this.txtPhonenumber.Size = new System.Drawing.Size(300, 25);
            this.txtPhonenumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.lblPhonenumberError.ForeColor = errorColor;
            this.lblPhonenumberError.Location = new System.Drawing.Point(formLeft, formTop + 50);
            this.lblPhonenumberError.Size = new System.Drawing.Size(300, 20);

            formTop += spacing;

            // فیلد نقش (کمبو باکس)
            this.lblRole.Text = "نقش:";
            this.lblRole.Location = new System.Drawing.Point(formLeft, formTop);
            this.lblRole.Size = new System.Drawing.Size(300, 20);
            this.lblRole.Font = persianFont;

            this.comboBoxRole.Items.AddRange(new object[] { "مدیر", "اپراتور", "راننده", "ادمین" });
            this.comboBoxRole.Location = new System.Drawing.Point(formLeft, formTop + 25);
            this.comboBoxRole.Size = new System.Drawing.Size(300, 25);
            this.comboBoxRole.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.lblRoleError.ForeColor = errorColor;
            this.lblRoleError.Location = new System.Drawing.Point(formLeft, formTop + 50);
            this.lblRoleError.Size = new System.Drawing.Size(300, 20);

            formTop += spacing;


            // lblVehicleType
            // 

            this.lblVehicleType.AutoSize = true;
            lblVehicleType.Location = new Point(formLeft + 320 + cmbVehicleType.Width + 10, formTop - 40);

            // موقعیت مناسب
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(100, 13);
            this.lblVehicleType.TabIndex = 15;
            this.lblVehicleType.Text = "نوع وسیله نقلیه:";
            this.lblVehicleType.Visible = false;

            // 
            // cmbVehicleType
            // 

            this.cmbVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehicleType.FormattingEnabled = true;
            this.cmbVehicleType.Items.AddRange(new object[] {
            "ماشین",
            "موتور",
               "ون",
            "سرویس مدارس"});
            cmbVehicleType.Location = new Point(formLeft + 300, formTop - 40);
            // کنار لیبل
            this.cmbVehicleType.Name = "cmbVehicleType";
            this.cmbVehicleType.Size = new System.Drawing.Size(150, 21);
            this.cmbVehicleType.TabIndex = 16;
            this.cmbVehicleType.Visible = false;

            this.comboBoxRole.SelectedIndexChanged += new System.EventHandler(this.comboBoxRole_SelectedIndexChanged);


            // 

            // فیلد آدرس
            this.lblAddress.Text = "آدرس:";
            this.lblAddress.Location = new System.Drawing.Point(formLeft, formTop);
            this.lblAddress.Size = new System.Drawing.Size(300, 20);
            this.lblAddress.Font = persianFont;

            this.txtAddress.Location = new System.Drawing.Point(formLeft, formTop + 25);
            this.txtAddress.Size = new System.Drawing.Size(300, 25);
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.lblAddressError = new System.Windows.Forms.Label();
            this.lblAddressError.ForeColor = errorColor;
            this.lblAddressError.Location = new System.Drawing.Point(formLeft, formTop + 50);
            this.lblAddressError.Size = new System.Drawing.Size(300, 20);

            formTop += spacing;

            // فیلد ایمیل
            this.lblEmail.Text = "ایمیل:";
            this.lblEmail.Location = new System.Drawing.Point(formLeft, formTop);
            this.lblEmail.Size = new System.Drawing.Size(300, 20);
            this.lblEmail.Font = persianFont;

            this.txtEmail.Location = new System.Drawing.Point(formLeft, formTop + 25);
            this.txtEmail.Size = new System.Drawing.Size(300, 25);
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.lblEmailError.ForeColor = errorColor;
            this.lblEmailError.Location = new System.Drawing.Point(formLeft, formTop + 50);
            this.lblEmailError.Size = new System.Drawing.Size(300, 20);

            formTop += spacing;

            // دکمه ثبت‌نام
            this.btnRegister.Text = "ثبت نام";
            this.btnRegister.Location = new System.Drawing.Point(formLeft + 60, formTop + 20);
            this.btnRegister.Size = new System.Drawing.Size(100, 35);
            this.btnRegister.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Click += new System.EventHandler(this.button1_Click);

            // دکمه بازگشت
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.btnBackToMain.Text = "بازگشت به صفحه اصلی";
            this.btnBackToMain.Location = new System.Drawing.Point(formLeft + 180, formTop + 20);
            this.btnBackToMain.Size = new System.Drawing.Size(150, 35);
            this.btnBackToMain.BackColor = System.Drawing.Color.Gray;
            this.btnBackToMain.ForeColor = System.Drawing.Color.White;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);


            // اضافه‌کردن تمام کنترل‌ها به فرم
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                panelRight,
                lblUsername, txtUsername, lblUsernameError,
                lblPassword, txtPassword, lblPasswordError,
                lblConfirmPassword, txtConfirmPassword, lblConfirmPasswordError,
                lblPhonenumber, txtPhonenumber, lblPhonenumberError,
                lblRole, comboBoxRole, lblRoleError,

                lblVehicleType, cmbVehicleType,
                lblAddress, txtAddress,lblAddressError,
                lblEmail, txtEmail, lblEmailError,
                btnRegister, btnBackToMain

            });

            // تنظیمات کلی فرم
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Text = "فرم ثبت نام";
            this.ResumeLayout(false);



        }




        #endregion

        // تعریف کنترل‌ها
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPhonenumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox comboBoxRole;

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBackToLogin;

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblPhonenumber;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblEmail;

        private System.Windows.Forms.Label lblUsernameError;
        private System.Windows.Forms.Label lblPasswordError;
        private System.Windows.Forms.Label lblConfirmPasswordError;
        private System.Windows.Forms.Label lblPhonenumberError;
        private System.Windows.Forms.Label lblRoleError;
        private System.Windows.Forms.Label lblEmailError;
        private System.Windows.Forms.Label lblAddressError;
        private System.Windows.Forms.Button btnBackToMain;
        private System.Windows.Forms.ComboBox cmbVehicleType;
        private System.Windows.Forms.Label lblVehicleType;







    }
}
