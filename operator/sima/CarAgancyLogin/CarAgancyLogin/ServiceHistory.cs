using System;
using System.Drawing;
using System.Windows.Forms;
using CarAgancyLogin.Controllers;
using CarAgancyLogin.Models;

namespace CarAgancyLogin
{
    public partial class Userhistory : UserControl
    {
        private string driverUsername; // ذخیره نام کاربری راننده برای دریافت اطلاعات رزروهای او

        public Userhistory(string username) // سازنده کنترل، نام کاربری راننده را دریافت و اطلاعات رزروها را بارگذاری می‌کند
        {
            InitializeComponent();
            driverUsername = username; // ذخیره نام کاربری راننده
            LoadReservations();  // بارگذاری لیست رزروها برای راننده

        }

        private void LoadReservations() // متدی برای بارگذاری رزروها از پایگاه داده
        {
            // ایجاد کنترلر برای دریافت داده‌های رزرو
            ReservationController controller = new ReservationController();
            // دریافت لیست رزروها برای این راننده خاص
            var reservations = controller.GetReservationsForDriver(driverUsername);

            listViewReservations.Items.Clear(); // پاک‌کردن آیتم‌های قبلی از لیست‌ویو

            foreach (var reservation in reservations) // افزودن هر رزرو به لیست‌ویو به صورت یک ردیف
            {
                // ایجاد آیتم جدید با تاریخ و زمان رزرو
                ListViewItem item = new ListViewItem(reservation.ReservationDate.ToString("yyyy/MM/dd HH:mm"));
                // افزودن اطلاعات مشتری، آدرس مبدا، مقصد و نوع رزرو به عنوان زیرآیتم
                item.SubItems.Add(reservation.CustomerName);
                item.SubItems.Add(reservation.SourceAddress);
                item.SubItems.Add(reservation.DestinationAddress);
                item.SubItems.Add(reservation.ReservationType);
                // افزودن آیتم به کنترل ListView
                listViewReservations.Items.Add(item);
            }
        }
        private void listViewReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void listViewReservations_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }
    }
}
