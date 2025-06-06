using System;
using System.Windows.Forms;
using CarAgancyLogin.Models;
using CarAgancyLogin.Controllers;
using CarAgancyLogin.Views;

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
            // در صورت نیاز به نمایش نام کاربری
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            // اعتبارسنجی
            if (string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(txtPlateNumber.Text) ||
                string.IsNullOrWhiteSpace(txtModel.Text) ||
                string.IsNullOrWhiteSpace(cmbColor.Text) ||
                numYear.Value == 0 ||
                string.IsNullOrWhiteSpace(cmbFuelType.Text))
            {
                MessageBox.Show("لطفاً تمام فیلدها را پر کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ساخت وسیله نقلیه
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

            // ثبت در دیتابیس
            VehicleController controller = new VehicleController();
            bool success = controller.AddVehicle(vehicle);

            if (success)
            {
                MessageBox.Show("ثبت وسیله نقلیه با موفقیت انجام شد!", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // نمایش فرم MainForm بدون پارامتر
                MainForm mainForm = new MainForm();
                mainForm.Show();

                // بستن فرم فعلی
                this.Close();
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
