using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using CarAgancyLogin.Models;

namespace CarAgancyLogin.Controllers
{
    public class ReservationController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // افزودن رزرو جدید
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

        // دریافت تعداد کل رزروها
        public int GetTotalReservations()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Reservations";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // دریافت لیست سرویس‌های مربوط به یک راننده خاص
        public List<Reservation> GetReservationsForDriver(string driverUsername)
        {
            List<Reservation> reservations = new List<Reservation>();

            string query = "SELECT ReservationDate, CustomerName, SourceAddress, DestinationAddress, ReservationType FROM Reservations WHERE DriverUsername = @DriverUsername";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@DriverUsername", driverUsername);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reservations.Add(new Reservation
                        {
                            ReservationDate = Convert.ToDateTime(reader["ReservationDate"]),
                            CustomerName = reader["CustomerName"].ToString(),
                            SourceAddress = reader["SourceAddress"].ToString(),
                            DestinationAddress = reader["DestinationAddress"].ToString(),
                            ReservationType = reader["ReservationType"].ToString()
                        });
                    }
                }
            }

            return reservations;
        }
    }
}
