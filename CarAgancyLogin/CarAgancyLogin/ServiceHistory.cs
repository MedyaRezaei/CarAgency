using System;
using System.Windows.Forms;
using CarAgancyLogin.Controllers;
using System.Linq;

namespace CarAgancyLogin
{
    public partial class Userhistory : UserControl
    {
        private string driverUsername;

        public Userhistory(string username)
        {
            InitializeComponent();
            driverUsername = username;

            LoadReservations(); // بارگذاری اولیه بدون فیلتر
        }

        private void LoadReservations(DateTime? startDate = null)
        {
            ReservationController controller = new ReservationController();
            var reservations = controller.GetReservationsForDriver(driverUsername);

            if (startDate.HasValue)
            {
                reservations = reservations
                    .Where(r => r.ReservationDate.Date >= startDate.Value.Date)
                    .ToList();
            }

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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime start = dtpStartDate.Value.Date;
            LoadReservations(start);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadReservations(); // بارگذاری همه رزروها بدون فیلتر
        }
    }
}
