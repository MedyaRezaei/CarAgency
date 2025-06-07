namespace CarAgancyLogin
{
    partial class Userhistory
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
            this.listViewReservations = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewReservations
            // 
            this.listViewReservations.BackColor = System.Drawing.Color.LightGray;
            this.listViewReservations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewReservations.FullRowSelect = true;
            this.listViewReservations.GridLines = true;
            this.listViewReservations.HideSelection = false;
            this.listViewReservations.Location = new System.Drawing.Point(112, 80);
            this.listViewReservations.Name = "listViewReservations";
            this.listViewReservations.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listViewReservations.RightToLeftLayout = true;
            this.listViewReservations.Size = new System.Drawing.Size(818, 613);
            this.listViewReservations.TabIndex = 14;
            this.listViewReservations.UseCompatibleStateImageBehavior = false;
            this.listViewReservations.View = System.Windows.Forms.View.Details;
            this.listViewReservations.SelectedIndexChanged += new System.EventHandler(this.listViewReservations_SelectedIndexChanged_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "تاریخ رزرو";
            this.columnHeader1.Width = 173;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "نام مشتری ";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "مبدا";
            this.columnHeader3.Width = 169;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "مقصد ";
            this.columnHeader4.Width = 170;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "نوع سرویس ";
            this.columnHeader5.Width = 180;
            // 
            // Userhistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.Controls.Add(this.listViewReservations);
            this.Name = "Userhistory";
            this.Size = new System.Drawing.Size(1796, 772);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewReservations;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
