using System.Windows.Forms;
using System.Drawing;
using System;
using System.Security.AccessControl;

namespace CarAgancyLogin.Views
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUsernameError = new System.Windows.Forms.Label();

            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPasswordError = new System.Windows.Forms.Label();

            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblConfirmPasswordError = new System.Windows.Forms.Label();

            this.txtPhonenumber = new System.Windows.Forms.TextBox();
            this.lblPhonenumber = new System.Windows.Forms.Label();
            this.lblPhonenumberError = new System.Windows.Forms.Label();

            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblRoleError = new System.Windows.Forms.Label();

            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddressError = new System.Windows.Forms.Label();

            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEmailError = new System.Windows.Forms.Label();

            this.txtLicenseNumber = new System.Windows.Forms.TextBox();
            this.lblLicenseNumber = new System.Windows.Forms.Label();
            this.lblLicenseNumberError=new System.Windows.Forms.Label();


            this.btnRegister = new System.Windows.Forms.Button();
            this.btnBackToMain = new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.panelRight = new Panel();
            this.panelRight.BackColor = ColorTranslator.FromHtml("#4ecdc4");
            this.panelRight.Dock = DockStyle.Right;
            this.panelRight.Width = 550;

            PictureBox picture = new PictureBox();
            picture.Image = Image.FromFile("evaluation.png");
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Size = new Size(150, 150);
            picture.Location = new Point((panelRight.Width - 150) / 2, 300);
            panelRight.Controls.Add(picture);

            this.lblWelcome = new Label();
            this.lblWelcome.Text = "به صفحه ی ثبت نام خوش آمدید";
            this.lblWelcome.Font = new Font("Tahoma", 20F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            this.lblWelcome.Size = new Size(500, 40);
            this.lblWelcome.Location = new Point(25, 180);

            this.lblSubtitle = new Label();
            this.lblSubtitle.Text = "برای ایجاد حساب کاربری اطلاعات خود را وارد کنید";
            this.lblSubtitle.Font = new Font("Tahoma", 14F);
            this.lblSubtitle.ForeColor = Color.White;
            this.lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblSubtitle.Size = new Size(500, 30);
            this.lblSubtitle.Location = new Point(25, 230);

            this.panelRight.Controls.Add(this.lblWelcome);
            this.panelRight.Controls.Add(this.lblSubtitle);

            Font persianFont = new Font("Tahoma", 10);
            Color errorColor = Color.Red;
            int formLeft = 30;
            int formTop = 30;
            int spacing = 70;

            this.lblUsername.Text = "نام کاربری:";
            this.lblUsername.Location = new Point(formLeft, formTop);
            this.lblUsername.Size = new Size(300, 20);
            this.lblUsername.Font = persianFont;

            this.txtUsername.Location = new Point(formLeft, formTop + 25);
            this.txtUsername.Size = new Size(300, 25);
            this.txtUsername.RightToLeft = RightToLeft.Yes;

            this.lblUsernameError.ForeColor = errorColor;
            this.lblUsernameError.Location = new Point(formLeft, formTop + 50);
            this.lblUsernameError.Size = new Size(300, 20);

            formTop += spacing;

            this.lblPassword.Text = "رمز عبور:";
            this.lblPassword.Location = new Point(formLeft, formTop);
            this.lblPassword.Size = new Size(300, 20);
            this.lblPassword.Font = persianFont;

            this.txtPassword.Location = new Point(formLeft, formTop + 25);
            this.txtPassword.Size = new Size(300, 25);
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.RightToLeft = RightToLeft.Yes;

            this.lblPasswordError.ForeColor = errorColor;
            this.lblPasswordError.Location = new Point(formLeft, formTop + 50);
            this.lblPasswordError.Size = new Size(300, 20);

            formTop += spacing;

            this.lblConfirmPassword.Text = "تکرار رمز عبور:";
            this.lblConfirmPassword.Location = new Point(formLeft, formTop);
            this.lblConfirmPassword.Size = new Size(300, 20);
            this.lblConfirmPassword.Font = persianFont;

            this.txtConfirmPassword.Location = new Point(formLeft, formTop + 25);
            this.txtConfirmPassword.Size = new Size(300, 25);
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.RightToLeft = RightToLeft.Yes;

            this.lblConfirmPasswordError.ForeColor = errorColor;
            this.lblConfirmPasswordError.Location = new Point(formLeft, formTop + 50);
            this.lblConfirmPasswordError.Size = new Size(300, 20);

            formTop += spacing;

            this.lblPhonenumber.Text = "شماره تلفن:";
            this.lblPhonenumber.Location = new Point(formLeft, formTop);
            this.lblPhonenumber.Size = new Size(300, 20);
            this.lblPhonenumber.Font = persianFont;

            this.txtPhonenumber.Location = new Point(formLeft, formTop + 25);
            this.txtPhonenumber.Size = new Size(300, 25);
            this.txtPhonenumber.RightToLeft = RightToLeft.Yes;

            this.lblPhonenumberError.ForeColor = errorColor;
            this.lblPhonenumberError.Location = new Point(formLeft, formTop + 50);
            this.lblPhonenumberError.Size = new Size(300, 20);

            formTop += spacing;

            this.lblRole.Text = "نقش:";
            this.lblRole.Location = new Point(formLeft, formTop);
            this.lblRole.Size = new Size(300, 20);
            this.lblRole.Font = persianFont;

            this.comboBoxRole.Items.AddRange(new object[] { "مدیر", "اپراتور", "راننده", "ادمین" });
            this.comboBoxRole.Location = new Point(formLeft, formTop + 25);
            this.comboBoxRole.Size = new Size(300, 25);
            this.comboBoxRole.RightToLeft = RightToLeft.Yes;

            this.lblRoleError.ForeColor = errorColor;
            this.lblRoleError.Location = new Point(formLeft, formTop + 50);
            this.lblRoleError.Size = new Size(300, 20);

            this.comboBoxRole.SelectedIndexChanged += new EventHandler(this.comboBoxRole_SelectedIndexChanged);

            formTop += spacing;

            this.lblLicenseNumber.Text = "شماره گواهینامه:";
            this.lblLicenseNumber.Location = new Point(formLeft, formTop);
            this.lblLicenseNumber.Size = new Size(300, 20);
            this.lblLicenseNumber.Font = persianFont;

            this.txtLicenseNumber.Location = new Point(formLeft, formTop + 25);
            this.txtLicenseNumber.Size = new Size(300, 25);
            this.txtLicenseNumber.RightToLeft = RightToLeft.Yes;
            this.lblLicenseNumberError.ForeColor=errorColor;
            this.lblLicenseNumberError.Location = new Point(formLeft,formTop + 50);
            this.lblLicenseNumberError.Size= new Size(300, 20);
            

            formTop += spacing;

            this.lblAddress.Text = "آدرس:";
            this.lblAddress.Location = new Point(formLeft, formTop);
            this.lblAddress.Size = new Size(300, 20);
            this.lblAddress.Font = persianFont;

            this.txtAddress.Location = new Point(formLeft, formTop + 25);
            this.txtAddress.Size = new Size(300, 25);
            this.txtAddress.RightToLeft = RightToLeft.Yes;

            this.lblAddressError.ForeColor = errorColor;
            this.lblAddressError.Location = new Point(formLeft, formTop + 50);
            this.lblAddressError.Size = new Size(300, 20);

            formTop += spacing;

            this.lblEmail.Text = "ایمیل:";
            this.lblEmail.Location = new Point(formLeft, formTop);
            this.lblEmail.Size = new Size(300, 20);
            this.lblEmail.Font = persianFont;

            this.txtEmail.Location = new Point(formLeft, formTop + 25);
            this.txtEmail.Size = new Size(300, 25);
            this.txtEmail.RightToLeft = RightToLeft.Yes;

            this.lblEmailError.ForeColor = errorColor;
            this.lblEmailError.Location = new Point(formLeft, formTop + 50);
            this.lblEmailError.Size = new Size(300, 20);

            formTop += spacing;

            this.btnRegister.Text = "ثبت نام";
            this.btnRegister.Location = new Point(formLeft + 60, formTop + 20);
            this.btnRegister.Size = new Size(100, 35);
            this.btnRegister.BackColor = Color.MediumSeaGreen;
            this.btnRegister.ForeColor = Color.White;
            this.btnRegister.Click += new EventHandler(this.button1_Click);

            this.btnBackToMain = new Button();
            this.btnBackToMain.Text = "بازگشت به صفحه اصلی";
            this.btnBackToMain.Location = new Point(formLeft + 180, formTop + 20);
            this.btnBackToMain.Size = new Size(150, 35);
            this.btnBackToMain.BackColor = Color.Gray;
            this.btnBackToMain.ForeColor = Color.White;
            this.btnBackToMain.Click += new EventHandler(this.btnBackToMain_Click);

            this.Controls.AddRange(new Control[] {
                panelRight,
                lblUsername, txtUsername, lblUsernameError,
                lblPassword, txtPassword, lblPasswordError,
                lblConfirmPassword, txtConfirmPassword, lblConfirmPasswordError,
                lblPhonenumber, txtPhonenumber, lblPhonenumberError,
                lblRole, comboBoxRole, lblRoleError,
                lblLicenseNumber, txtLicenseNumber,
                lblAddress, txtAddress, lblAddressError,
                lblEmail, txtEmail, lblEmailError,
                btnRegister, btnBackToMain,lblLicenseNumberError
            });

            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ClientSize = new Size(900, 600);
            this.Text = "فرم ثبت نام";
            this.ResumeLayout(false);
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelRight;
        private Label lblWelcome;
        private Label lblSubtitle;

        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private TextBox txtPhonenumber;
        private TextBox txtAddress;
        private TextBox txtEmail;
        private TextBox txtLicenseNumber;
        private ComboBox comboBoxRole;

        private Button btnRegister;
        private Button btnBackToMain;

        private Label lblUsername;
        private Label lblPassword;
        private Label lblConfirmPassword;
        private Label lblPhonenumber;
        private Label lblRole;
        private Label lblAddress;
        private Label lblEmail;
        private Label lblLicenseNumber;

        private Label lblUsernameError;
        private Label lblPasswordError;
        private Label lblConfirmPasswordError;
        private Label lblPhonenumberError;
        private Label lblRoleError;
        private Label lblEmailError;
        private Label lblAddressError;
        private Label lblLicenseNumberError;
    }
}
