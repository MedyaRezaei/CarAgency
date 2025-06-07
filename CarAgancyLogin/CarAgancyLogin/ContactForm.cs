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
    public partial class ContactForm : UserControl
    {
        public ContactForm()
        {
            InitializeComponent(); // مقداردهی اولیه به اجزای فرم
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        // کلیک روی دکمه‌ی تلگرام: کپی کردن آیدی به کلیپ‌بورد
        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("@CarAgency"); // کپی آیدی تلگرام در کلیپ‌بورد
            MessageBox.Show("آیدی تلگرام در کلیپ‌بورد کپی شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // کلیک روی دکمه‌ی واتساپ: کپی شماره در کلیپ‌بورد
        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("09121234567"); // کپی شماره واتساپ در کلیپ‌بورد
            MessageBox.Show("شماره واتساپ در کلیپ‌بورد کپی شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
