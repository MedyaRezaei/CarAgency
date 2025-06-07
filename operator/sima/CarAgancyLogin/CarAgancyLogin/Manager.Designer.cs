namespace CarAgancyLogin
{
    partial class Manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnOperatorHours = new System.Windows.Forms.Button();
            this.btnAccounting = new System.Windows.Forms.Button();
            this.btnTeamInfo = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.homeImage = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.SkyBlue;
            this.panelTop.Controls.Add(this.btnDashboard);
            this.panelTop.Controls.Add(this.btnOperatorHours);
            this.panelTop.Controls.Add(this.btnAccounting);
            this.panelTop.Controls.Add(this.btnTeamInfo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1924, 143);
            this.panelTop.TabIndex = 0;
            // 
            // btnOperatorHours
            // 
            this.btnOperatorHours.BackColor = System.Drawing.SystemColors.Info;
            this.btnOperatorHours.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperatorHours.Location = new System.Drawing.Point(726, 37);
            this.btnOperatorHours.Name = "btnOperatorHours";
            this.btnOperatorHours.Size = new System.Drawing.Size(235, 70);
            this.btnOperatorHours.TabIndex = 2;
            this.btnOperatorHours.Text = "ساعات کاری";
            this.btnOperatorHours.UseVisualStyleBackColor = false;
            this.btnOperatorHours.Click += new System.EventHandler(this.btnOperatorHours_Click);
            // 
            // btnAccounting
            // 
            this.btnAccounting.BackColor = System.Drawing.SystemColors.Info;
            this.btnAccounting.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccounting.Location = new System.Drawing.Point(1040, 37);
            this.btnAccounting.Name = "btnAccounting";
            this.btnAccounting.Size = new System.Drawing.Size(235, 70);
            this.btnAccounting.TabIndex = 1;
            this.btnAccounting.Text = "حسابداری";
            this.btnAccounting.UseVisualStyleBackColor = false;
            this.btnAccounting.Click += new System.EventHandler(this.btnAccounting_Click);
            // 
            // btnTeamInfo
            // 
            this.btnTeamInfo.BackColor = System.Drawing.SystemColors.Info;
            this.btnTeamInfo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeamInfo.Location = new System.Drawing.Point(1349, 37);
            this.btnTeamInfo.Name = "btnTeamInfo";
            this.btnTeamInfo.Size = new System.Drawing.Size(235, 70);
            this.btnTeamInfo.TabIndex = 0;
            this.btnTeamInfo.Text = "اطلاعات تیم";
            this.btnTeamInfo.UseVisualStyleBackColor = false;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.SteelBlue;
            this.panelContent.Controls.Add(this.label1);
            this.panelContent.Controls.Add(this.homeImage);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 143);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1924, 907);
            this.panelContent.TabIndex = 1;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1727, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 72);
            this.label1.TabIndex = 1;
            this.label1.Text = "مدیر";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.SystemColors.Info;
            this.btnDashboard.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Location = new System.Drawing.Point(378, 37);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(235, 70);
            this.btnDashboard.TabIndex = 3;
            this.btnDashboard.Text = "بازگشت به داشبورد";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // homeImage
            // 
            this.homeImage.Image = ((System.Drawing.Image)(resources.GetObject("homeImage.Image")));
            this.homeImage.Location = new System.Drawing.Point(223, 27);
            this.homeImage.Name = "homeImage";
            this.homeImage.Size = new System.Drawing.Size(1440, 900);
            this.homeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.homeImage.TabIndex = 0;
            this.homeImage.TabStop = false;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.Name = "Manager";
            this.Text = "Form1";
            this.panelTop.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.homeImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnOperatorHours;
        private System.Windows.Forms.Button btnAccounting;
        private System.Windows.Forms.Button btnTeamInfo;
        private System.Windows.Forms.PictureBox homeImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDashboard;
    }
}