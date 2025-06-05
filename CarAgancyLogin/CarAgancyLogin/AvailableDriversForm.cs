using System;
using System.Windows.Forms;
using CarAgancyLogin.Controllers;

namespace CarAgancyLogin
{
    public partial class AvailableDriversForm : UserControl
    {
        public AvailableDriversForm()
        {
            InitializeComponent(); // مهم! برای بارگذاری کنترل‌های گرافیکی
        }

        // موقع لود یوزر کنترل، راننده‌ها رو بگیره
        private void AvailableDriversForm_Load(object sender, EventArgs e)
        {
            try
            {
                UserController controller = new UserController();
                var drivers = controller.GetAllAvailableDriversWithDetails();

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = drivers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در بارگذاری رانندگان: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // اگر خواستی کلیک روی سلول‌ها رو هندل کنی، اینجا اضافه کن
        }
    }
}
