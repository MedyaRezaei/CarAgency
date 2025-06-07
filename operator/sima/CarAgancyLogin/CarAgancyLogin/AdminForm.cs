using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            // وصل کردن رویداد کلیک به دکمه بازگشت به داشبورد
            btnBackToDashboard.Click += btnBackToDashboard_Click;
        }

        // رویداد کلیک دکمه بازگشت به داشبورد

        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            this.Hide(); // پنهان کردن فرم فعلی (فرم ادمین)
            MainForm dashboard = new MainForm(); // ایجاد نمونه‌ای از فرم اصلی
            dashboard.FormClosed += (s, args) => this.Close(); // بستن فرم ادمین بعد از بستن فرم اصلی
            dashboard.Show(); // نمایش فرم اصلی
        }

        // رویداد کلیک دکمه پشتیبان‌گیری
        private void btnBackup_Click(object sender, EventArgs e)
        {
            // نمایش پیام تأیید از کاربر
            DialogResult result = MessageBox.Show("آیا مطمئن هستید که می‌خواهید از دیتابیس پشتیبان‌گیری کنید؟",
                                          "تأیید پشتیبان‌گیری",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // باز کردن پنجره انتخاب محل ذخیره فایل
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Backup Files (*.bak)|*.bak";
                    saveFileDialog.Title = "محل ذخیره فایل پشتیبان را انتخاب کنید";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string connectionString = "Data Source=.;Initial Catalog=CarAgencyLogin;Integrated Security=True";
                        string backupPath = saveFileDialog.FileName; // مسیر انتخاب‌شده توسط کاربر

                        // دستور SQL برای پشتیبان‌گیری
                        string query = $@"
                    BACKUP DATABASE CarAgencyLogin 
                    TO DISK = N'{backupPath}' 
                    WITH FORMAT, MEDIANAME = 'CarAgencyBackup', NAME = 'Full Backup of CarAgencyLogin'";

                        try
                        {
                            // اجرای دستور پشتیبان‌گیری
                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                SqlCommand cmd = new SqlCommand(query, conn);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("✅ پشتیبان‌گیری با موفقیت انجام شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("❌ خطا در پشتیبان‌گیری:\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // رویداد کلیک دکمه بازیابی
        private void btnRestore_Click(object sender, EventArgs e)
        {
            // نمایش پیام هشدار قبل از بازیابی
            DialogResult result = MessageBox.Show("⚠️ با بازیابی، تمام اطلاعات فعلی جایگزین خواهند شد.\nآیا مطمئن هستید که می‌خواهید بازیابی انجام شود؟",
                                          "هشدار بازیابی",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // باز کردن فایل پشتیبان توسط کاربر
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Backup Files (*.bak)|*.bak";
                    openFileDialog.Title = "فایل پشتیبان را انتخاب کنید";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string connectionString = "Data Source=.;Initial Catalog=master;Integrated Security=True";
                        string backupPath = openFileDialog.FileName;

                        try
                        {
                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                conn.Open();
                                // تغییر وضعیت دیتابیس به تک‌کاربره
                                string setSingleUser = "ALTER DATABASE CarAgencyLogin SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                                // دستور بازیابی
                                string restoreQuery = $@"
                            RESTORE DATABASE CarAgencyLogin 
                            FROM DISK = N'{backupPath}' 
                            WITH REPLACE";
                                // بازگرداندن وضعیت به چندکاربره
                                string setMultiUser = "ALTER DATABASE CarAgencyLogin SET MULTI_USER";
                                // اجرای دستورات به ترتیب
                                SqlCommand cmd1 = new SqlCommand(setSingleUser, conn);
                                SqlCommand cmd2 = new SqlCommand(restoreQuery, conn);
                                SqlCommand cmd3 = new SqlCommand(setMultiUser, conn);

                                cmd1.ExecuteNonQuery();
                                cmd2.ExecuteNonQuery();
                                cmd3.ExecuteNonQuery();

                                MessageBox.Show("✅ بازیابی با موفقیت انجام شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("❌ خطا در بازیابی:\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
