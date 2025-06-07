using System;
using System.Data.SqlClient;
using CarAgancyLogin.Models;

namespace CarAgancyLogin.Controllers
{
    public class FeedbackController
    {
        private readonly string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";

        public bool HasAlreadyVoted(int reservationId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT COUNT(*) FROM Feedbacks WHERE ReservationId = @id", conn);
                cmd.Parameters.AddWithValue("@id", reservationId);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void SubmitFeedback(int reservationId, int rating)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // تغییر اصلی: اضافه کردن FeedbackDate به دستور INSERT
                var cmd = new SqlCommand(
                    "INSERT INTO Feedbacks (ReservationId, Rating, FeedbackDate) VALUES (@resId, @rate, @date)",
                    conn);

                cmd.Parameters.AddWithValue("@resId", reservationId);
                cmd.Parameters.AddWithValue("@rate", rating);
                cmd.Parameters.AddWithValue("@date", DateTime.Now); // اضافه کردن تاریخ فعلی

                cmd.ExecuteNonQuery();
            }
        }
    }
}