using System;
using System.Data.SqlClient;

namespace CarAgancyLogin.Controllers
{
    public class FeedbackController
    {
        private readonly string connectionString = "Data Source=SIMA\\SQLEXPRESS;Initial Catalog=CarAgencyLogin;Integrated Security=True";

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
                var cmd = new SqlCommand("INSERT INTO Feedbacks (ReservationId, Rating) VALUES (@resId, @rate)", conn);
                cmd.Parameters.AddWithValue("@resId", reservationId);
                cmd.Parameters.AddWithValue("@rate", rating);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
