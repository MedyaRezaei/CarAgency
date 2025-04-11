


namespace CarAgancyLogin.Views
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();

            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtcombobox = new System.Windows.Forms.ComboBox();

            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.lblForgotPassword = new System.Windows.Forms.Label();

            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();

            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Name = "LoginForm";
            this.Text = "فرم ورود";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(78, 205, 196);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Width = 600;
            this.panelLeft.Controls.Add(this.lblTitle);
            this.panelLeft.Controls.Add(this.lblWelcome);
            this.panelLeft.Controls.Add(this.lblInstruction);

          

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "آژانس خودرو";
            this.lblTitle.Font = new System.Drawing.Font("B Nazanin", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(230, 100);

            // 
            // lblWelcome
            // 
            this.lblWelcome.Text = "به صفحه‌ی ورود خوش آمدید";
            this.lblWelcome.Font = new System.Drawing.Font("B Nazanin", 20F);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(130, 200);

            // 
            // lblInstruction
            // 
            this.lblInstruction.Text = "برای ورود به صفحه ی شخصی اطلاعات خورا وارد کنید";
            this.lblInstruction.Font = new System.Drawing.Font("B Nazanin", 14F);
            this.lblInstruction.ForeColor = System.Drawing.Color.White;
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(100, 260);

            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.BackColor = System.Drawing.ColorTranslator.FromHtml("#EEEEEE");

            this.panelRight.Controls.Add(this.lblUsername);
            this.panelRight.Controls.Add(this.txtUsername);
            this.panelRight.Controls.Add(this.lblPassword);
            this.panelRight.Controls.Add(this.txtPassword);
            this.panelRight.Controls.Add(this.lblRole);
            this.panelRight.Controls.Add(this.txtcombobox);
            this.panelRight.Controls.Add(this.btnLogin);
            this.panelRight.Controls.Add(this.btnSignUp);
            this.panelRight.Controls.Add(this.lblForgotPassword);

            //
            // Controls Positioning
            //
            int startX = 180;
            int startY = 100;
            int inputWidth = 300;
            int labelHeight = 25;
            int fieldHeight = 30;
            int spacingY = 70;

            // 
            // lblUsername
            // 
            this.lblUsername.Text = "نام کاربری";
            this.lblUsername.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(startX + inputWidth - 60, startY);

            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(startX, startY + labelHeight);
            this.txtUsername.Size = new System.Drawing.Size(inputWidth, fieldHeight);
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            // 
            // lblPassword
            // 
            this.lblPassword.Text = "رمز عبور";
            this.lblPassword.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(startX + inputWidth - 50, startY + spacingY);

            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(startX, startY + spacingY + labelHeight);
            this.txtPassword.Size = new System.Drawing.Size(inputWidth, fieldHeight);
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.PasswordChar = '*';

            // 
            // lblRole
            // 
            this.lblRole.Text = "نقش";
            this.lblRole.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(startX + inputWidth - 30, startY + 2 * spacingY);

            // 
            // txtcombobox
            // 
            this.txtcombobox.Items.AddRange(new object[] { "مدیر", "اپراتور", "راننده", "ادمین" });
            this.txtcombobox.Location = new System.Drawing.Point(startX, startY + 2 * spacingY + labelHeight);
            this.txtcombobox.Size = new System.Drawing.Size(inputWidth, fieldHeight);
            this.txtcombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtcombobox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            // 
            // btnLogin
            // 
            this.btnLogin.Text = "ورود";
            this.btnLogin.Location = new System.Drawing.Point(startX, startY + 3 * spacingY + 10);
            this.btnLogin.Size = new System.Drawing.Size(inputWidth, 35);
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(78, 205, 196);
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_Click);

            // 
            // btnSignUp
            // 
            this.btnSignUp.Text = "ثبت‌نام";
            this.btnSignUp.Location = new System.Drawing.Point(startX, startY + 3 * spacingY + 60);
            this.btnSignUp.Size = new System.Drawing.Size(inputWidth, 35);
            this.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignUp.Click += new System.EventHandler(this.btnGoToRegister_Click);

            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.Text = "فراموشی رمز عبور؟";
            this.lblForgotPassword.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Underline);
            this.lblForgotPassword.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblForgotPassword.Location = new System.Drawing.Point(startX + 170, startY + 3 * spacingY + 110);
            this.lblForgotPassword.AutoSize = true;
            this.lblForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgotPassword.Click += new System.EventHandler(this.btnForgotPassword_Click);

            //
            // Add Panels to Form
            //
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);

            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblInstruction;

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox txtcombobox;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Label lblForgotPassword;
    }
}
