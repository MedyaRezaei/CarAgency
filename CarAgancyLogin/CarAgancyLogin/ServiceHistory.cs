using System;
using System.Drawing;
using System.Windows.Forms;
using CarAgancyLogin.Controllers;
using CarAgancyLogin.Models;

namespace CarAgancyLogin
{
    public partial class Userhistory : UserControl
    {
        private string driverUsername;

        public Userhistory(string username)
        {
            InitializeComponent();
            driverUsername = username;
            LoadReservations();

        }

        private void LoadReservations()
        {
            ReservationController controller = new ReservationController();
            var reservations = controller.GetReservationsForDriver(driverUsername);

            listViewReservations.Items.Clear();

            foreach (var reservation in reservations)
            {
                ListViewItem item = new ListViewItem(reservation.ReservationDate.ToString("yyyy/MM/dd HH:mm"));
                item.SubItems.Add(reservation.CustomerName);
                item.SubItems.Add(reservation.SourceAddress);
                item.SubItems.Add(reservation.DestinationAddress);
                item.SubItems.Add(reservation.ReservationType);

                listViewReservations.Items.Add(item);
            }
        }

        private void listViewReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
            // انتخاب آیتم خاص اگر نیاز بود
        }

        private void listViewReservations_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
