using CarAgancyLogin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class OperatorForm : Form
    {
        public OperatorForm()
        {
            InitializeComponent();
        }

        private void OperatorForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; // فرم تمام صفحه
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerReservation registerPage = new CustomerReservation();
            LoadUserControl(registerPage);
        }

        private void LoadUserControl(UserControl uc)
        {
            panel1.Controls.Clear();         // حذف کنترل قبلی
            uc.Dock = DockStyle.Fill;        // پر کردن کامل پنل
            panel1.Controls.Add(uc);         // اضافه کردن کنترل جدید
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); // مخفی کردن فرم اپراتور
            MainForm main = new MainForm(); // ساخت فرم اصلی
            main.Show(); //


            //this.Hide(); // مخفی کردن فرم فعلی (اپراتور)
            //LoginForm loginForm = new LoginForm();
            //loginForm.Show(); // نمایش فرم لاگین مجدد
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AvailableDriversForm availableDrivers = new AvailableDriversForm();
            LoadUserControl(availableDrivers);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // نمایش دوباره فرم اپراتور
            OperatorForm operatorForm = new OperatorForm();
            operatorForm.Show();

            // مخفی کردن فرم فعلی (مثلاً فرم اصلی یا هر فرم واسط دیگه)
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // پاک کردن محتوای قبلی
            EndTripUserControl endTripControl = new EndTripUserControl();
            endTripControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(endTripControl);
        }
    }
    }

    

