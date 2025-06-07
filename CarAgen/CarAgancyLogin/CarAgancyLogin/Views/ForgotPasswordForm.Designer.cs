namespace CarAgancyLogin.Views
{
    partial class ForgotPasswordForm
    {
        // متغیر برای نگهداری منابع فرم
        private System.ComponentModel.IContainer components = null;

        // پاک‌سازی منابع مورد استفاده
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // طراحی اجزای گرافیکی فرم
        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnBackToLogin = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();

            // جعبه‌ی متن نام کاربری
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.Font = new System.Drawing.Font("Simplified Arabic", 9F, System.Drawing.FontStyle.Bold);
            this.txtUsername.Location = new System.Drawing.Point(881, 168);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(357, 37);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);

            // جعبه‌ی متن رمز جدید
            this.txtNewPassword.BackColor = System.Drawing.Color.White;
            this.txtNewPassword.Font = new System.Drawing.Font("Simplified Arabic", 9F, System.Drawing.FontStyle.Bold);
            this.txtNewPassword.Location = new System.Drawing.Point(878, 270);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(357, 37);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.UseSystemPasswordChar = true;

            // جعبه‌ی متن تأیید رمز عبور
            this.txtConfirm.BackColor = System.Drawing.Color.White;
            this.txtConfirm.Font = new System.Drawing.Font("Simplified Arabic", 9F, System.Drawing.FontStyle.Bold);
            this.txtConfirm.Location = new System.Drawing.Point(879, 368);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '*';
            this.txtConfirm.Size = new System.Drawing.Size(357, 37);
            this.txtConfirm.TabIndex = 2;
            this.txtConfirm.UseSystemPasswordChar = true;
            this.txtConfirm.TextChanged += new System.EventHandler(this.txtConfirm_TextChanged);

            // دکمه‌ی بازیابی رمز عبور
            this.btnChangePassword.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnChangePassword.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChangePassword.Location = new System.Drawing.Point(878, 428);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(358, 53);
            this.btnChangePassword.TabIndex = 3;
            this.btnChangePassword.Text = "بازیابی رمز";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);

            // دکمه‌ی بازگشت به فرم ورود
            this.btnBackToLogin.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnBackToLogin.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.btnBackToLogin.Location = new System.Drawing.Point(1126, 505);
            this.btnBackToLogin.Name = "btnBackToLogin";
            this.btnBackToLogin.Size = new System.Drawing.Size(112, 50);
            this.btnBackToLogin.TabIndex = 4;
            this.btnBackToLogin.Text = "بازگشت";
            this.btnBackToLogin.UseVisualStyleBackColor = false;
            this.btnBackToLogin.Click += new System.EventHandler(this.btnBackToLogin_Click_1);

            // پنل سمت چپ (اطلاعات خوش‌آمدگویی)
            this.panelLeft.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panelLeft.Controls.Add(this.textBox6);
            this.panelLeft.Controls.Add(this.textBox5);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(611, 632);
            this.panelLeft.TabIndex = 5;

            // متن "اطلاعات خود را وارد کنید"
            this.textBox6.BackColor = System.Drawing.Color.MediumTurquoise;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Simplified Arabic", 16F, System.Drawing.FontStyle.Bold);
            this.textBox6.ForeColor = System.Drawing.Color.White;
            this.textBox6.Location = new System.Drawing.Point(140, 306);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(277, 54);
            this.textBox6.TabIndex = 9;
            this.textBox6.Text = "اطلاعات خود را وارد کنید";

            // متن "جهت بازیابی رمز عبور"
            this.textBox5.BackColor = System.Drawing.Color.MediumTurquoise;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Simplified Arabic", 20F, System.Drawing.FontStyle.Bold);
            this.textBox5.ForeColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(118, 233);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(324, 67);
            this.textBox5.TabIndex = 8;
            this.textBox5.Text = "جهت بازیابی رمز عبور";

            // پنل سمت راست (فرم)
            // پنل سمت راست (فرم)
            this.panelRight.BackColor = System.Drawing.ColorTranslator.FromHtml("#EEEEEE");

            this.panelRight.Controls.Add(this.lblMessage);
            this.panelRight.Controls.Add(this.textBox4);
            this.panelRight.Controls.Add(this.btnBackToLogin);
            this.panelRight.Controls.Add(this.textBox3);
            this.panelRight.Controls.Add(this.btnChangePassword);
            this.panelRight.Controls.Add(this.textBox2);
            this.panelRight.Controls.Add(this.textBox1);
            this.panelRight.Controls.Add(this.txtUsername);
            this.panelRight.Controls.Add(this.txtNewPassword);
            this.panelRight.Controls.Add(this.txtConfirm);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1263, 632);
            this.panelRight.TabIndex = 6;

            // نمایش پیام هشدار یا موفقیت
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(1011, 498);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(51, 20);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.Text = "label1";
            this.lblMessage.Visible = false;

            // برچسب "تأیید رمز عبور"
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.BackColor = System.Drawing.ColorTranslator.FromHtml("#EEEEEE");
            this.textBox4.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.textBox4.Location = new System.Drawing.Point(1105, 321);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(130, 40);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = ":تایید رمز عبور";

            // برچسب "رمز عبور جدید"
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.BackColor = System.Drawing.ColorTranslator.FromHtml("#EEEEEE");
            this.textBox3.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.textBox3.Location = new System.Drawing.Point(1105, 223);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(133, 40);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = ":رمز عبور جدید";

            // برچسب "نام کاربری"
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.BackColor = System.Drawing.ColorTranslator.FromHtml("#EEEEEE");
            this.textBox2.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.textBox2.Location = new System.Drawing.Point(1147, 121);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(91, 40);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = ":نام کاربری";

            // عنوان فرم
            // عنوان فرم
            this.textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#EEEEEE");

            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Simplified Arabic", 20F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.textBox1.Location = new System.Drawing.Point(1000, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 67);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "بازیابی رمز عبور";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);

            // تنظیمات کلی فرم
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 632);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Name = "ForgotPasswordForm";
            this.Text = "ForgotPasswordForm";
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);
        }

        // تعریف کنترل‌ها
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnBackToLogin;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
    }
}
