namespace CarAgancyLogin
{
    partial class TeamInfoUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridTeamInfo = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchDriver = new System.Windows.Forms.TextBox();
            this.btnDeleteDriver = new System.Windows.Forms.Button();
            this.dataGridDrivers = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchOperator = new System.Windows.Forms.TextBox();
            this.btnDeleteOperator = new System.Windows.Forms.Button();
            this.dataGridOperators = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnBackToHome_Click = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchAdmin = new System.Windows.Forms.TextBox();
            this.btnDeleteAdmin = new System.Windows.Forms.Button();
            this.dataGridAdmins = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTeamInfo)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDrivers)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOperators)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAdmins)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTeamInfo
            // 
            this.dataGridTeamInfo.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dataGridTeamInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTeamInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridTeamInfo.Location = new System.Drawing.Point(0, 0);
            this.dataGridTeamInfo.Name = "dataGridTeamInfo";
            this.dataGridTeamInfo.RowHeadersWidth = 62;
            this.dataGridTeamInfo.RowTemplate.Height = 28;
            this.dataGridTeamInfo.Size = new System.Drawing.Size(1124, 668);
            this.dataGridTeamInfo.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1124, 668);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtSearchDriver);
            this.tabPage1.Controls.Add(this.btnDeleteDriver);
            this.tabPage1.Controls.Add(this.dataGridDrivers);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1116, 635);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "راننده ها";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1004, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "🔍 جستجو:";
            // 
            // txtSearchDriver
            // 
            this.txtSearchDriver.Location = new System.Drawing.Point(700, 151);
            this.txtSearchDriver.Name = "txtSearchDriver";
            this.txtSearchDriver.Size = new System.Drawing.Size(251, 26);
            this.txtSearchDriver.TabIndex = 8;
            this.txtSearchDriver.TextChanged += new System.EventHandler(this.txtSearchDriver_TextChanged);
            // 
            // btnDeleteDriver
            // 
            this.btnDeleteDriver.BackColor = System.Drawing.Color.RosyBrown;
            this.btnDeleteDriver.Location = new System.Drawing.Point(969, 464);
            this.btnDeleteDriver.Name = "btnDeleteDriver";
            this.btnDeleteDriver.Size = new System.Drawing.Size(100, 35);
            this.btnDeleteDriver.TabIndex = 1;
            this.btnDeleteDriver.Text = "حذف";
            this.btnDeleteDriver.UseVisualStyleBackColor = false;
            this.btnDeleteDriver.Click += new System.EventHandler(this.btnDeleteDriver_Click);
            // 
            // dataGridDrivers
            // 
            this.dataGridDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDrivers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDrivers.Location = new System.Drawing.Point(42, 199);
            this.dataGridDrivers.Name = "dataGridDrivers";
            this.dataGridDrivers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridDrivers.RowHeadersWidth = 62;
            this.dataGridDrivers.RowTemplate.Height = 28;
            this.dataGridDrivers.Size = new System.Drawing.Size(1027, 250);
            this.dataGridDrivers.TabIndex = 0;
            this.dataGridDrivers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDrivers_CellContentClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtSearchOperator);
            this.tabPage2.Controls.Add(this.btnDeleteOperator);
            this.tabPage2.Controls.Add(this.dataGridOperators);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1116, 635);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "اپراتورها";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(944, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "🔍 جستجو:";
            // 
            // txtSearchOperator
            // 
            this.txtSearchOperator.Location = new System.Drawing.Point(644, 139);
            this.txtSearchOperator.Name = "txtSearchOperator";
            this.txtSearchOperator.Size = new System.Drawing.Size(251, 26);
            this.txtSearchOperator.TabIndex = 5;
            this.txtSearchOperator.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnDeleteOperator
            // 
            this.btnDeleteOperator.BackColor = System.Drawing.Color.RosyBrown;
            this.btnDeleteOperator.Location = new System.Drawing.Point(909, 452);
            this.btnDeleteOperator.Name = "btnDeleteOperator";
            this.btnDeleteOperator.Size = new System.Drawing.Size(100, 35);
            this.btnDeleteOperator.TabIndex = 1;
            this.btnDeleteOperator.Text = "حذف";
            this.btnDeleteOperator.UseVisualStyleBackColor = false;
            this.btnDeleteOperator.Click += new System.EventHandler(this.btnDeleteOperator_Click);
            // 
            // dataGridOperators
            // 
            this.dataGridOperators.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOperators.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridOperators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOperators.Location = new System.Drawing.Point(106, 181);
            this.dataGridOperators.Name = "dataGridOperators";
            this.dataGridOperators.RowHeadersWidth = 62;
            this.dataGridOperators.RowTemplate.Height = 28;
            this.dataGridOperators.Size = new System.Drawing.Size(903, 250);
            this.dataGridOperators.TabIndex = 0;
            this.dataGridOperators.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOperators_CellContentClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnBackToHome_Click);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.txtSearchAdmin);
            this.tabPage3.Controls.Add(this.btnDeleteAdmin);
            this.tabPage3.Controls.Add(this.dataGridAdmins);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1116, 635);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ادمین ها";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnBackToHome_Click
            // 
            this.btnBackToHome_Click.BackColor = System.Drawing.Color.RosyBrown;
            this.btnBackToHome_Click.Location = new System.Drawing.Point(106, 451);
            this.btnBackToHome_Click.Name = "btnBackToHome_Click";
            this.btnBackToHome_Click.Size = new System.Drawing.Size(100, 35);
            this.btnBackToHome_Click.TabIndex = 7;
            this.btnBackToHome_Click.Text = "بازگشت";
            this.btnBackToHome_Click.UseVisualStyleBackColor = false;
            this.btnBackToHome_Click.Click += new System.EventHandler(this.btnBackToHome_Click_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(944, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "🔍 جستجو:";
            // 
            // txtSearchAdmin
            // 
            this.txtSearchAdmin.Location = new System.Drawing.Point(644, 139);
            this.txtSearchAdmin.Name = "txtSearchAdmin";
            this.txtSearchAdmin.Size = new System.Drawing.Size(251, 26);
            this.txtSearchAdmin.TabIndex = 5;
            this.txtSearchAdmin.TextChanged += new System.EventHandler(this.textBox3_TextChanged_1);
            // 
            // btnDeleteAdmin
            // 
            this.btnDeleteAdmin.BackColor = System.Drawing.Color.RosyBrown;
            this.btnDeleteAdmin.Location = new System.Drawing.Point(909, 451);
            this.btnDeleteAdmin.Name = "btnDeleteAdmin";
            this.btnDeleteAdmin.Size = new System.Drawing.Size(100, 35);
            this.btnDeleteAdmin.TabIndex = 1;
            this.btnDeleteAdmin.Text = "حذف";
            this.btnDeleteAdmin.UseVisualStyleBackColor = false;
            this.btnDeleteAdmin.Click += new System.EventHandler(this.btnDeleteAdmin_Click);
            // 
            // dataGridAdmins
            // 
            this.dataGridAdmins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridAdmins.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAdmins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAdmins.Location = new System.Drawing.Point(106, 181);
            this.dataGridAdmins.Name = "dataGridAdmins";
            this.dataGridAdmins.RowHeadersWidth = 62;
            this.dataGridAdmins.RowTemplate.Height = 28;
            this.dataGridAdmins.Size = new System.Drawing.Size(903, 250);
            this.dataGridAdmins.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.Location = new System.Drawing.Point(106, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "بازگشت";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RosyBrown;
            this.button2.Location = new System.Drawing.Point(42, 464);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 35);
            this.button2.TabIndex = 10;
            this.button2.Text = "بازگشت";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TeamInfoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridTeamInfo);
            this.Name = "TeamInfoUserControl";
            this.Size = new System.Drawing.Size(1124, 668);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTeamInfo)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDrivers)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOperators)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAdmins)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridTeamInfo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridDrivers;
        private System.Windows.Forms.Button btnDeleteDriver;
        private System.Windows.Forms.Button btnDeleteOperator;
        private System.Windows.Forms.DataGridView dataGridOperators;
        private System.Windows.Forms.Button btnDeleteAdmin;
        private System.Windows.Forms.DataGridView dataGridAdmins;
        private System.Windows.Forms.TextBox txtSearchDriver;
        private System.Windows.Forms.TextBox txtSearchOperator;
        private System.Windows.Forms.TextBox txtSearchAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBackToHome_Click;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
