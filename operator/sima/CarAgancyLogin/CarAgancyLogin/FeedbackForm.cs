using CarAgancyLogin.Controllers;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class FeedbackForm : UserControl
    {
        public FeedbackForm()
        {
            InitializeComponent(); // مقداردهی اولیه کنترل‌های فرم

            // وصل کردن ایونت دکمه ثبت
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red; // رنگ متن خطا را قرمز تنظیم می‌کنیم
            label4.Text = "";   // پاک‌کردن پیام قبلی

            string username = textBox1.Text.Trim(); // گرفتن نام از مشتری 

            if (string.IsNullOrEmpty(username))  // بررسی خالی بودن نام کاربری
            {
                label4.Text = "لطفاً نام مشتری را وارد کنید.";
                return;
            }

            // تعیین امتیاز بر اساس دکمه انتخاب‌شده
            int rating = 0;
            if (radioButton1.Checked) rating = 1;
            else if (radioButton2.Checked) rating = 2;
            else if (radioButton3.Checked) rating = 3;
            else if (radioButton4.Checked) rating = 4;
            else if (radioButton5.Checked) rating = 5;
            // بررسی اینکه امتیازی انتخاب شده باشد
            if (rating == 0)
            {
                label4.Text = "لطفاً امتیاز را انتخاب کنید.";
                return;
            }
            // اتصال به پایگاه‌داده SQL Server برای بررسی وجود مشتری
            string connectionString = "Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True";
            int reservationId = -1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT TOP 1 Id FROM Reservations WHERE CustomerName = @username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                // گرفتن اولین رزرو مربوط به این مشتری
                var result = cmd.ExecuteScalar();
                if (result == null)
                {
                    label4.Text = "❌ مشتری با این نام یافت نشد.";
                    return;
                }
                reservationId = Convert.ToInt32(result); // تبدیل نتیجه به عدد صحیح
            }

            var controller = new FeedbackController();
            if (controller.HasAlreadyVoted(reservationId))
            { // بررسی اینکه آیا قبلاً رأی داده شده یا نه
                label4.ForeColor = Color.Orange;
                label4.Text = "⚠️ شما قبلاً رأی داده‌اید.";
                return;
            }
            // ثبت امتیاز در پایگاه‌داده
            controller.SubmitFeedback(reservationId, rating);
            label4.ForeColor = Color.Green;
            label4.Text = "✔️ رأی شما با موفقیت ثبت شد.";

            // تعیین متن بازخورد برای ذخیره در فایل متنی
            string voteText = "";
            if (radioButton1.Checked) voteText = "خیلی ضعیف";
            else if (radioButton2.Checked) voteText = "ضعیف";
            else if (radioButton3.Checked) voteText = "متوسط";
            else if (radioButton4.Checked) voteText = "خوب";
            else if (radioButton5.Checked) voteText = "عالی";
            // ذخیره بازخورد در فایل متنی
            if (!string.IsNullOrEmpty(voteText))
            {
                File.AppendAllText("feedback.txt", voteText + Environment.NewLine);
                MessageBox.Show("بازخورد شما با موفقیت ثبت شد");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
        private void FeedbackForm_Load(object sender, EventArgs e)
        {
            textBox1.RightToLeft = RightToLeft.Yes; // راست‌چین کردن ورودی نام مشتری
        }
    }
}
