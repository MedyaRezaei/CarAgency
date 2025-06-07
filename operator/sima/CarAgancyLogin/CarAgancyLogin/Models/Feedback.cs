using System;

namespace CarAgancyLogin.Models
{
    public class Feedback
    {
        public int Id { get; set; }                    // کلید اصلی
        public int ReservationId { get; set; }         // آیدی رزرو (کلید خارجی)
        public int Rating { get; set; }                // امتیاز بین ۱ تا ۵
        public DateTime FeedbackDate { get; set; }     // تاریخ ثبت بازخورد
    }
}
