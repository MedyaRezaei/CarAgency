namespace CarAgancyLogin.Views
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtcombobox = new System.Windows.Forms.ComboBox();
            this.btnLogin_Click = new System.Windows.Forms.Button();
            this.btnGoToRegister = new System.Windows.Forms.Button();
            this.btnForgotPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(370, 64);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(312, 22);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(370, 107);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(312, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtcombobox
            // 
            this.txtcombobox.FormattingEnabled = true;
            this.txtcombobox.Location = new System.Drawing.Point(370, 144);
            this.txtcombobox.Name = "txtcombobox";
            this.txtcombobox.Size = new System.Drawing.Size(310, 24);
            this.txtcombobox.TabIndex = 3;
            // 
            // btnLogin_Click
            // 
            this.btnLogin_Click.Location = new System.Drawing.Point(370, 201);
            this.btnLogin_Click.Name = "btnLogin_Click";
            this.btnLogin_Click.Size = new System.Drawing.Size(312, 23);
            this.btnLogin_Click.TabIndex = 4;
            this.btnLogin_Click.Text = "button1";
            this.btnLogin_Click.UseVisualStyleBackColor = true;
            this.btnLogin_Click.Click += new System.EventHandler(this.btnLogin_Click_Click);
            // 
            // btnGoToRegister
            // 
            this.btnGoToRegister.Location = new System.Drawing.Point(573, 252);
            this.btnGoToRegister.Name = "btnGoToRegister";
            this.btnGoToRegister.Size = new System.Drawing.Size(109, 23);
            this.btnGoToRegister.TabIndex = 5;
            this.btnGoToRegister.Text = "button2";
            this.btnGoToRegister.UseVisualStyleBackColor = true;
            this.btnGoToRegister.Click += new System.EventHandler(this.btnGoToRegister_Click);
            // 
            // btnForgotPassword
            // 
            this.btnForgotPassword.Location = new System.Drawing.Point(602, 326);
            this.btnForgotPassword.Name = "btnForgotPassword";
            this.btnForgotPassword.Size = new System.Drawing.Size(75, 23);
            this.btnForgotPassword.TabIndex = 6;
            this.btnForgotPassword.Text = "button1";
            this.btnForgotPassword.UseVisualStyleBackColor = true;
            this.btnForgotPassword.Click += new System.EventHandler(this.btnForgotPassword_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnForgotPassword);
            this.Controls.Add(this.btnGoToRegister);
            this.Controls.Add(this.btnLogin_Click);
            this.Controls.Add(this.txtcombobox);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox txtcombobox;
        private System.Windows.Forms.Button btnLogin_Click;
        private System.Windows.Forms.Button btnGoToRegister;
        private System.Windows.Forms.Button btnForgotPassword;
    }
}