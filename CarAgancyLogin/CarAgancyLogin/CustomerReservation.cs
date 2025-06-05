using CarAgancyLogin.Controllers;
using CarAgancyLogin.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class CustomerReservation : UserControl
    {
        private readonly UserController userController;
        private readonly ReservationController reservationController;

        public CustomerReservation()
        {
            InitializeComponent();
            userController = new UserController();
            reservationController = new ReservationController();
        }

        private void CustomerReservation_Load(object sender, EventArgs e)
       
        {
            // پر کردن ComboBox نوع وسیله
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "ماشین", "موتور", "ون", "سرویس مدارس" });
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            // 🚫 فقط اجازه انتخاب (نه تایپ دستی)
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            // 🔠 راست‌چین کردن متن داخل تکست‌باکس‌ها
            textBox1.RightToLeft = RightToLeft.Yes;
            textBox2.RightToLeft = RightToLeft.Yes;
            textBox3.RightToLeft = RightToLeft.Yes;
            textBox4.RightToLeft = RightToLeft.Yes;

            LoadDrivers(); // پیش‌فرض: همه راننده‌ها
        }

        

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                LoadDrivers(comboBox1.SelectedItem.ToString());
            }
        }

        private void LoadDrivers(string vehicleType = null)
        {
            var availableDrivers = string.IsNullOrEmpty(vehicleType)
                ? userController.GetAvailableDrivers()
                : userController.GetAvailableDriversByVehicleType(vehicleType);

            comboBox2.DataSource = null;
            comboBox2.DataSource = availableDrivers;
            comboBox2.DisplayMember = "Username";
            comboBox2.ValueMember = "Username";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            var reservation = new Reservation
            {
                CustomerName = textBox1.Text.Trim(),
                PhoneNumber = textBox2.Text.Trim(),
                SourceAddress = textBox3.Text.Trim(),
                DestinationAddress = textBox4.Text.Trim(),
                ReservationType = comboBox1.SelectedItem.ToString(),
                DriverUsername = comboBox2.SelectedValue.ToString(),
                ReservationDate = dateTimePicker1.Value
            };

            bool isSaved = reservationController.AddReservation(reservation);

            if (isSaved)
            {
                MessageBox.Show("رزرو با موفقیت ثبت شد.");
                userController.SetDriverAvailability(reservation.DriverUsername, false);
                LoadDrivers(reservation.ReservationType);
                ResetForm();
            }
            else
            {
                MessageBox.Show("خطا در ذخیره رزرو. لطفاً مجدداً تلاش کنید.");
            }
        }


        private bool ValidateFields()
        {
            // بررسی اینکه هیچ فیلدی خالی نباشد
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                comboBox1.SelectedItem == null ||
                comboBox2.SelectedItem == null)
            {
                MessageBox.Show("لطفاً تمام فیلدها را به‌درستی پر کنید.");
                return false;
            }

            // بررسی اینکه شماره تلفن دقیقا 11 رقم باشد و فقط عدد باشد
            string phoneNumber = textBox2.Text.Trim();
            if (phoneNumber.Length != 11 || !phoneNumber.All(char.IsDigit))
            {
                MessageBox.Show("شماره تلفن باید دقیقا ۱۱ رقم عددی باشد.");
                return false;
            }

            return true;
        }

        //private bool ValidateFields()
        //{
        //    if (string.IsNullOrWhiteSpace(textBox1.Text) ||
        //        string.IsNullOrWhiteSpace(textBox2.Text) ||
        //        string.IsNullOrWhiteSpace(textBox3.Text) ||
        //        string.IsNullOrWhiteSpace(textBox4.Text) ||
        //        comboBox1.SelectedItem == null ||
        //        comboBox2.SelectedItem == null)
        //    {
        //        MessageBox.Show("لطفاً تمام فیلدها را به‌درستی پر کنید.");
        //        return false;
        //    }
        //    return true;
        //}

        private void ResetForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
        }

        // خالی نگه‌داشتن رویدادهای لازم برای سازگاری با Designer
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
