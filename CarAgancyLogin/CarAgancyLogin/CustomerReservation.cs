using CarAgancyLogin.Controllers;
using CarAgancyLogin.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class CustomerReservation : UserControl
    {
        // نمونه‌هایی از کنترلرها برای مدیریت کاربران و رزروها
        private readonly UserController userController;
        private readonly ReservationController reservationController;

        public CustomerReservation()
        {
            InitializeComponent(); // مقداردهی اولیه کنترل‌ها
            userController = new UserController();
            reservationController = new ReservationController();
        }

        private void CustomerReservation_Load(object sender, EventArgs e)
       
        {
            // پر کردن ComboBox نوع وسیله
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "خودرو", "موتور", "ون", "سرویس مدارس" });
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            // تنظیم کمبوباکس‌ها فقط برای انتخاب (نه تایپ دستی)
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            //  راست‌چین کردن متن داخل تکست‌باکس‌ها
            textBox1.RightToLeft = RightToLeft.Yes;
            textBox2.RightToLeft = RightToLeft.Yes;
            textBox3.RightToLeft = RightToLeft.Yes;
            textBox4.RightToLeft = RightToLeft.Yes;

            LoadDrivers(); // پیش‌فرض: همه راننده‌ها
        }

        // وقتی کاربر نوع وسیله را انتخاب می‌کند
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                LoadDrivers(comboBox1.SelectedItem.ToString()); // فیلتر کردن راننده‌ها بر اساس نوع وسیله
            }
        }

        // بارگذاری لیست راننده‌ها (در صورت نیاز بر اساس نوع وسیله)
        private void LoadDrivers(string vehicleType = null)
        {
            // اگر نوع وسیله مشخص نشده، راننده‌های غیرقابل استفاده را برگردان
            var availableDrivers = string.IsNullOrEmpty(vehicleType)
                ? userController.GetUnavailableDrivers()
                : userController.GetAvailableDriversByVehicleType(vehicleType);
            // اتصال راننده‌ها به کمبوباکس دوم
            comboBox2.DataSource = null;
            comboBox2.DataSource = availableDrivers;
            comboBox2.DisplayMember = "Username";  // نمایش نام کامل راننده
            comboBox2.ValueMember = "Username";

        }

        // دکمه‌ی ثبت رزرو
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return; // اگر اعتبارسنجی ناموفق بود، ادامه نده

            var reservation = new Reservation // ساخت شی رزرو از اطلاعات واردشده
            {
                CustomerName = textBox1.Text.Trim(),
                PhoneNumber = textBox2.Text.Trim(),
                SourceAddress = textBox3.Text.Trim(),
                DestinationAddress = textBox4.Text.Trim(),
                ReservationType = comboBox1.SelectedItem.ToString(),
                DriverUsername = comboBox2.SelectedValue.ToString(),
                ReservationDate = dateTimePicker1.Value
            };
            // ذخیره رزرو در پایگاه داده
            bool isSaved = reservationController.AddReservation(reservation);

            if (isSaved)
            {
                // پیام موفقیت و بروزرسانی وضعیت راننده
                MessageBox.Show("رزرو با موفقیت ثبت شد.");
                userController.SetDriverAvailability(reservation.DriverUsername, false); // راننده را غیرفعال کن
                LoadDrivers(reservation.ReservationType); // بارگذاری مجدد لیست راننده‌ها
                ResetForm();
            }
            else
            {
                MessageBox.Show("خطا در ذخیره رزرو. لطفاً مجدداً تلاش کنید.");
            }
        }

        // اعتبارسنجی فیلدهای فرم
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

        // پاک‌سازی تمام فیلدهای فرم
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
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }
    }
}
