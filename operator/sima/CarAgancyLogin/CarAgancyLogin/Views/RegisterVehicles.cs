using System;
using System.Windows.Forms;
using CarAgancyLogin.Models;      // اگه Vehicle رو اینجا گذاشتی
using CarAgancyLogin.Controllers; // اگه VehicleController رو اینجا گذاشتی

namespace CarAgancyLogin.Views
{
    public partial class RegisterVehicles : Form
    {
        private string _username;

        public RegisterVehicles()
        {
            InitializeComponent();
        }

        public RegisterVehicles(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void RegisterVehicles_Load(object sender, EventArgs e)
        {
            // نمایش نام کاربری راننده
            
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            // اعتبارسنجی فیلدهای فرم
            if (string.IsNullOrWhiteSpace(comboBox1.Text) ||    // نوع وسیله نقلیه
                string.IsNullOrWhiteSpace(txtPlateNumber.Text) || // شماره پلاک
                string.IsNullOrWhiteSpace(txtModel.Text) ||       // برند/مدل
                string.IsNullOrWhiteSpace(cmbColor.Text) ||       // رنگ
                numYear.Value == 0 ||                             // سال ساخت
                string.IsNullOrWhiteSpace(cmbFuelType.Text))      // نوع سوخت
            {
                MessageBox.Show("لطفاً تمام فیلدها را پر کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ایجاد شیء Vehicle بر اساس ورودی فرم
            Vehicle vehicle = new Vehicle
            {
                DriverUsername = _username,
                VehicleType = comboBox1.Text,
                PlateNumber = txtPlateNumber.Text,
                Model = txtModel.Text,
                Color = cmbColor.Text,
                ManufactureYear = (int)numYear.Value,
                FuelType = cmbFuelType.Text,
                InsuranceExpiryDate = dtpInsurance.Value
            };

            // ثبت در دیتابیس توسط کنترلر
            VehicleController controller = new VehicleController();
            bool success = controller.AddVehicle(vehicle);

            if (success)
            {
                MessageBox.Show("ثبت وسیله نقلیه با موفقیت انجام شد!", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // یا فرم بعدی رو باز کن
            }
            else
            {
                MessageBox.Show("خطا در ثبت وسیله نقلیه!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
