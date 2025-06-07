namespace CarAgancyLogin
{
    partial class WorkHoursUserControl
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
            this.dataGridWorkHours = new System.Windows.Forms.DataGridView();
            this.dataGridDriversList = new System.Windows.Forms.DataGridView();
            this.btnBackToHome = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDriverHoursResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWorkHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDriversList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridWorkHours
            // 
            this.dataGridWorkHours.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dataGridWorkHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridWorkHours.Location = new System.Drawing.Point(0, 0);
            this.dataGridWorkHours.Name = "dataGridWorkHours";
            this.dataGridWorkHours.RowHeadersWidth = 62;
            this.dataGridWorkHours.RowTemplate.Height = 28;
            this.dataGridWorkHours.Size = new System.Drawing.Size(1924, 907);
            this.dataGridWorkHours.TabIndex = 0;
            // 
            // dataGridDriversList
            // 
            this.dataGridDriversList.BackgroundColor = System.Drawing.Color.Linen;
            this.dataGridDriversList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDriversList.Location = new System.Drawing.Point(922, 132);
            this.dataGridDriversList.Name = "dataGridDriversList";
            this.dataGridDriversList.RowHeadersWidth = 62;
            this.dataGridDriversList.RowTemplate.Height = 28;
            this.dataGridDriversList.Size = new System.Drawing.Size(695, 197);
            this.dataGridDriversList.TabIndex = 13;
            // 
            // btnBackToHome
            // 
            this.btnBackToHome.BackColor = System.Drawing.Color.RosyBrown;
            this.btnBackToHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToHome.Location = new System.Drawing.Point(59, 689);
            this.btnBackToHome.Name = "btnBackToHome";
            this.btnBackToHome.Size = new System.Drawing.Size(100, 35);
            this.btnBackToHome.TabIndex = 15;
            this.btnBackToHome.Text = "بازگشت";
            this.btnBackToHome.UseVisualStyleBackColor = false;
            this.btnBackToHome.Click += new System.EventHandler(this.btnBackToHome_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnBackToHome);
            this.panel1.Location = new System.Drawing.Point(65, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1806, 809);
            this.panel1.TabIndex = 17;
            // 
            // lblDriverHoursResult
            // 
            this.lblDriverHoursResult.BackColor = System.Drawing.Color.Linen;
            this.lblDriverHoursResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverHoursResult.Location = new System.Drawing.Point(700, 67);
            this.lblDriverHoursResult.Name = "lblDriverHoursResult";
            this.lblDriverHoursResult.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDriverHoursResult.Size = new System.Drawing.Size(922, 36);
            this.lblDriverHoursResult.TabIndex = 2;
            this.lblDriverHoursResult.Text = "لطفاً یک راننده را برای مشاهده ساعت کاری انتخاب کنید";
            this.lblDriverHoursResult.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(421, 52);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(251, 87);
            this.label2.TabIndex = 1;
            this.label2.Text = "ساعت کاری هر اپراتور:  \r\n8 ساعت\r\n\r\n";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 74);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(314, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "ساعت کاری ادمین:\r\n6 ساعت\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Linen;
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(967, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 200);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Linen;
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(59, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(780, 200);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Linen;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.lblDriverHoursResult);
            this.panel4.Controls.Add(this.dataGridDriversList);
            this.panel4.Location = new System.Drawing.Point(59, 304);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1688, 358);
            this.panel4.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarAgancyLogin.Properties.Resources.calculator_2312200;
            this.pictureBox1.Location = new System.Drawing.Point(303, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(304, 289);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CarAgancyLogin.Properties.Resources.six_3840755;
            this.pictureBox2.Location = new System.Drawing.Point(126, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 130);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CarAgancyLogin.Properties.Resources.number_8_3840772;
            this.pictureBox3.Location = new System.Drawing.Point(112, 37);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(130, 130);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // WorkHoursUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridWorkHours);
            this.Name = "WorkHoursUserControl";
            this.Size = new System.Drawing.Size(1924, 907);
            this.Load += new System.EventHandler(this.WorkHoursUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWorkHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDriversList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridWorkHours;
        private System.Windows.Forms.DataGridView dataGridDriversList;
        private System.Windows.Forms.Button btnBackToHome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDriverHoursResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
