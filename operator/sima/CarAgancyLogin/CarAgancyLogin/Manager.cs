using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;

namespace CarAgancyLogin
{
    public partial class Manager : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Manager()
        {
            InitializeComponent();

            // بدون قاب شدن فرم
            this.FormBorderStyle = FormBorderStyle.None;

            // اتصال رویدادهای فرم
            this.Load += ManagerForm_Load;
            this.Resize += (s, e) => MakePanelRounded(panelContent);

            // اتصال رویدادهای درگ برای فرم
            this.MouseDown += Manager_MouseDown;
            this.MouseMove += Manager_MouseMove;
            this.MouseUp += Manager_MouseUp;
        }

        // ✅ پراپرتی‌های عمومی برای دسترسی از یوزرکنترل
        public PictureBox HomeImage => homeImage;
        public Label WelcomeLabel => label1;
        public Panel MainPanel => panelContent;

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            MakePanelRounded(panelContent);

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ControlBox = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;

            btnTeamInfo.Click += btnTeamInfo_Click;

            // نمایش تصویر و لیبل خوشامدگویی
            panelContent.Controls.Clear();
            panelContent.Controls.Add(label1);
            panelContent.Controls.Add(homeImage);
            homeImage.Dock = DockStyle.Fill;
            label1.Visible = true;
            homeImage.Visible = true;
            btnOperatorHours.Click += btnOperatorHours_Click;
            btnDashboard.Click += btnDashboard_Click;

        }

        private void MakePanelRounded(Panel panel)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 1000;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddLine(radius, 0, panel.Width, 0);
            path.AddLine(panel.Width, 0, panel.Width, panel.Height);
            path.AddLine(panel.Width, panel.Height, 0, panel.Height);
            path.AddLine(0, panel.Height, 0, radius);
            path.CloseFigure();

            panel.Region = new Region(path);
        }

        private void Manager_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Manager_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Manager_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        // رویداد کلیک دکمه اطلاعات تیم
        private void btnTeamInfo_Click(object sender, EventArgs e)
        {
            panelContent.Region = null;

            // مخفی کردن عکس و متن خوشامد
            homeImage.Visible = false;
            label1.Visible = false;

            // حذف کنترل‌های قبلی
            panelContent.Controls
                .OfType<UserControl>()
                .ToList()
                .ForEach(uc => panelContent.Controls.Remove(uc));

            // نمایش یوزرکنترل اطلاعات تیم
            TeamInfoUserControl teamControl = new TeamInfoUserControl();
            teamControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(teamControl);
        }


        private void btnOperatorHours_Click(object sender, EventArgs e)
        {
            panelContent.Region = null;

            // مخفی کردن عکس و لیبل خوشامدگویی
            homeImage.Visible = false;
            label1.Visible = false;

            // حذف کنترل‌های قبلی
            panelContent.Controls
                .OfType<UserControl>()
                .ToList()
                .ForEach(uc => panelContent.Controls.Remove(uc));

            // اضافه کردن یوزرکنترل ساعات کاری
            WorkHoursUserControl workHoursControl = new WorkHoursUserControl();
            workHoursControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(workHoursControl);
        }

        private void btnAccounting_Click(object sender, EventArgs e)
        {
            // حذف Region برای پنل (برگشت به شکل مستطیلی)
            panelContent.Region = null;

            // مخفی کردن عکس و لیبل خوشامدگویی
            homeImage.Visible = false;
            label1.Visible = false;

            // حذف کنترل‌های قبلی که از نوع UserControl هستند
            panelContent.Controls
                .OfType<UserControl>()
                .ToList()
                .ForEach(uc => panelContent.Controls.Remove(uc));

            // اضافه کردن یوزرکنترل حسابداری
            AccountingUserControl accountingControl = new AccountingUserControl();
            accountingControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(accountingControl);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}
