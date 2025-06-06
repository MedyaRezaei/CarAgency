using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class ServiceReport : UserControl
    {
        private string connectionString = @"Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
        private string loggedInUsername;
        private DateTime defaultDate = DateTime.Now.Date;

        public ServiceReport(string username)
        {
            InitializeComponent();
            this.loggedInUsername = username;
        }

        private void ServiceReport_Load(object sender, EventArgs e)
        {
            LoadDrivers();
            dtpServiceDate.Value = defaultDate; // مقداردهی اولیه به کنترل تاریخ
            LoadAllReservations();
        }

        private void LoadDrivers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT DISTINCT DriverUsername FROM Reservations";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                cmbDrivers.Items.Clear();
                cmbDrivers.Items.Add("همه راننده‌ها");

                while (reader.Read())
                {
                    cmbDrivers.Items.Add(reader["DriverUsername"].ToString());
                }

                cmbDrivers.SelectedIndex = 0;
            }
        }

        private void LoadAllReservations(string dateFilter = null, string driverFilter = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Reservations WHERE 1 = 1";

                if (!string.IsNullOrEmpty(dateFilter))
                {
                    query += " AND CAST(ReservationDate AS DATE) = @Date";
                }

                if (!string.IsNullOrEmpty(driverFilter) && driverFilter != "همه راننده‌ها")
                {
                    query += " AND DriverUsername = @Driver";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                if (!string.IsNullOrEmpty(dateFilter))
                    cmd.Parameters.AddWithValue("@Date", dateFilter);

                if (!string.IsNullOrEmpty(driverFilter) && driverFilter != "همه راننده‌ها")
                    cmd.Parameters.AddWithValue("@Driver", driverFilter);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvServices.DataSource = dt;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedDriver = cmbDrivers.SelectedItem?.ToString();

            string selectedDate = null;
            if (dtpServiceDate.Value.Date != defaultDate)
            {
                selectedDate = dtpServiceDate.Value.Date.ToString("yyyy-MM-dd");
            }

            LoadAllReservations(selectedDate, selectedDriver);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbDrivers.SelectedIndex = 0;
            dtpServiceDate.Value = defaultDate;
            LoadAllReservations();
        }

        private void cmbDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // اگر خواستی فیلتر خودکار اعمال بشه
            // btnFilter_Click(sender, e);
        }

        private void dtpServiceDate_ValueChanged(object sender, EventArgs e)
        {
            // اگر خواستی فیلتر خودکار اعمال بشه
            // btnFilter_Click(sender, e);
        }

        private void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // برای نمایش جزئیات رکورد
        }
    }
}
