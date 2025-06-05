using System.Data.SqlClient;
using System.Configuration;
using CarAgancyLogin.Models;

namespace CarAgancyLogin.Controllers
{
    public class ReservationController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public bool AddReservation(Reservation reservation)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Reservations (CustomerName, PhoneNumber, SourceAddress, DestinationAddress, ReservationType, DriverUsername, ReservationDate) " +
               "VALUES (@CustomerName, @PhoneNumber, @SourceAddress, @DestinationAddress, @ReservationType, @DriverUsername, @ReservationDate)";


                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerName", reservation.CustomerName);
                cmd.Parameters.AddWithValue("@PhoneNumber", reservation.PhoneNumber);
                cmd.Parameters.AddWithValue("@SourceAddress", reservation.SourceAddress);
                cmd.Parameters.AddWithValue("@DestinationAddress", reservation.DestinationAddress);
                cmd.Parameters.AddWithValue("@ReservationType", reservation.ReservationType);
                cmd.Parameters.AddWithValue("@DriverUsername", reservation.DriverUsername);
                cmd.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);


                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public int GetTotalReservations()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Reservations";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }

    }
}
