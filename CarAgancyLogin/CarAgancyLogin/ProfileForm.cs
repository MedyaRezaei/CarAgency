using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarAgancyLogin
{
    public partial class ProfileForm : UserControl
    {
        private string username; // نگهداری نام کاربری وارد شده

        public ProfileForm(string username)
        {
            InitializeComponent();
            this.username = username;
            // بارگذاری اطلاعات کاربر
            LoadUserProfile(username);
        }

        // بارگذاری اطلاعات کاربر از جدول Users
        private void LoadUserProfile(string username)
        {
            string connectionString = @"Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string userQuery = "SELECT * FROM Users WHERE Username = @Username";
                using (SqlCommand userCmd = new SqlCommand(userQuery, conn))
                {
                    userCmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = userCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {// مقداردهی فیلدهای پروفایل با اطلاعات کاربر
                            txtUsername.Text = reader["Username"].ToString();
                            txtPhone.Text = reader["Phonenumber"].ToString();
                            txtRole.Text = reader["Role"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtLicense.Text = reader["LicenseNumber"].ToString();

                            string role = reader["Role"].ToString();
                            reader.Close();

                            if (role == "راننده") // اگر کاربر راننده باشد، اطلاعات خودرو را هم بارگذاری کن
                            {
                                SetVehicleInfoVisibility(true);
                                LoadVehicleInfo(conn, username);
                            }
                            else
                            {
                                SetVehicleInfoVisibility(false);
                            }
                        }
                        else
                        {
                            MessageBox.Show("کاربر یافت نشد.");
                        }
                    }
                }
            }
        }
        // بارگذاری اطلاعات خودرو برای راننده
        private void LoadVehicleInfo(SqlConnection conn, string username)
        {
            string vehicleQuery = "SELECT * FROM Vehicles WHERE DriverUsername = @DriverUsername";
            using (SqlCommand cmd = new SqlCommand(vehicleQuery, conn))
            {
                cmd.Parameters.AddWithValue("@DriverUsername", username);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtVType.Text = reader["VehicleType"].ToString();
                        txtPlate.Text = reader["PlateNumber"].ToString();
                        txtModel.Text = reader["Model"].ToString();
                        txtColor.Text = reader["Color"].ToString();
                        txtYear.Text = reader["ManufactureYear"].ToString();
                        txtFuel.Text = reader["FuelType"].ToString();

                        if (reader["InsuranceExpiryDate"] != DBNull.Value)
                        {
                            txtInsurance.Text = Convert.ToDateTime(reader["InsuranceExpiryDate"]).ToShortDateString();
                        }
                        else
                        {
                            txtInsurance.Text = "";
                        }
                    }
                    else
                    { // اگر خودرو ثبت نشده بود، فیلدها خالی شوند
                        txtVType.Text = "";
                        txtPlate.Text = "";
                        txtModel.Text = "";
                        txtColor.Text = "";
                        txtYear.Text = "";
                        txtFuel.Text = "";
                        txtInsurance.Text = "";
                    }
                }
            }
        }

        private void SetVehicleInfoVisibility(bool visible)
        { // نمایش یا پنهان‌سازی فیلدهای مربوط به خودرو
            txtVType.Visible = visible;
            txtPlate.Visible = visible;
            txtModel.Visible = visible;
            txtColor.Visible = visible;
            txtYear.Visible = visible;
            txtFuel.Visible = visible;
            txtInsurance.Visible = visible;

            lblVehicleInfo.Visible = visible;
            lblVType.Visible = visible;
            lblPlate.Visible = visible;
            lblModel.Visible = visible;
            lblColor.Visible = visible;
            lblYear.Visible = visible;
            lblFuel.Visible = visible;
            lblInsurance.Visible = visible;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEditable(true); // فعال‌سازی فیلدها برای ویرایش
            btnSave.Visible = true; // نمایش دکمه ذخیره
            btnEdit.Enabled = false; // غیر فعال کردن دکمه ویرایش
        }
        private void SetEditable(bool editable) // فعال یا غیرفعال کردن فیلدها برای ویرایش
        {
            txtUsername.ReadOnly = !editable;
            txtPhone.ReadOnly = !editable;
            txtRole.ReadOnly = true;  // نقش نباید قابل ویرایش باشد
            txtAddress.ReadOnly = !editable;
            txtEmail.ReadOnly = !editable;
            txtLicense.ReadOnly = !editable;

            txtVType.ReadOnly = !editable;
            txtPlate.ReadOnly = !editable;
            txtModel.ReadOnly = !editable;
            txtColor.ReadOnly = !editable;
            txtYear.ReadOnly = !editable;
            txtFuel.ReadOnly = !editable;
            txtInsurance.ReadOnly = !editable;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-PFSU0HD;Initial Catalog=CarAgencyLogin;Integrated Security=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // آپدیت اطلاعات کاربر بر اساس Username
                    string updateUserQuery = @"
                UPDATE Users SET
                    Phonenumber = @Phone,
                    Address = @Address,
                    Email = @Email,
                    LicenseNumber = @License
                WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(updateUserQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@License", txtLicense.Text);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.ExecuteNonQuery();
                    }

                    // اگر نقش راننده بود، اطلاعات خودرو را به‌روزرسانی یا درج کن
                    if (txtRole.Text == "راننده")
                    { // بررسی وجود خودرو برای این راننده
                        string checkVehicleQuery = "SELECT COUNT(*) FROM Vehicles WHERE DriverUsername = @DriverUsername";
                        bool vehicleExists = false;
                        using (SqlCommand checkCmd = new SqlCommand(checkVehicleQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@DriverUsername", username);
                            int count = (int)checkCmd.ExecuteScalar();
                            vehicleExists = count > 0;
                        }

                        int manufactureYear = 0;
                        int.TryParse(txtYear.Text, out manufactureYear);

                        object insuranceDate = DBNull.Value;
                        if (DateTime.TryParse(txtInsurance.Text, out DateTime insDate))
                        {
                            insuranceDate = insDate;
                        }

                        if (vehicleExists) // به‌روزرسانی اطلاعات خودرو
                        {
                            string updateVehicleQuery = @"
                        UPDATE Vehicles SET
                            VehicleType = @VType,
                            PlateNumber = @Plate,
                            Model = @Model,
                            Color = @Color,
                            ManufactureYear = @Year,
                            FuelType = @Fuel,
                            InsuranceExpiryDate = @Insurance
                        WHERE DriverUsername = @DriverUsername";

                            using (SqlCommand cmd = new SqlCommand(updateVehicleQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@VType", txtVType.Text);
                                cmd.Parameters.AddWithValue("@Plate", txtPlate.Text);
                                cmd.Parameters.AddWithValue("@Model", txtModel.Text);
                                cmd.Parameters.AddWithValue("@Color", txtColor.Text);
                                cmd.Parameters.AddWithValue("@Year", manufactureYear);
                                cmd.Parameters.AddWithValue("@Fuel", txtFuel.Text);
                                cmd.Parameters.AddWithValue("@Insurance", insuranceDate);
                                cmd.Parameters.AddWithValue("@DriverUsername", username);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else // درج اطلاعات خودرو جدید
                        {
                            string insertVehicleQuery = @"
                        INSERT INTO Vehicles 
                            (DriverUsername, VehicleType, PlateNumber, Model, Color, ManufactureYear, FuelType, InsuranceExpiryDate)
                        VALUES
                            (@DriverUsername, @VType, @Plate, @Model, @Color, @Year, @Fuel, @Insurance)";

                            using (SqlCommand cmd = new SqlCommand(insertVehicleQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@DriverUsername", username);
                                cmd.Parameters.AddWithValue("@VType", txtVType.Text);
                                cmd.Parameters.AddWithValue("@Plate", txtPlate.Text);
                                cmd.Parameters.AddWithValue("@Model", txtModel.Text);
                                cmd.Parameters.AddWithValue("@Color", txtColor.Text);
                                cmd.Parameters.AddWithValue("@Year", manufactureYear);
                                cmd.Parameters.AddWithValue("@Fuel", txtFuel.Text);
                                cmd.Parameters.AddWithValue("@Insurance", insuranceDate);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("اطلاعات با موفقیت ذخیره شد.");

                    SetEditable(false);
                    btnSave.Visible = false;
                    btnEdit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در ذخیره اطلاعات: " + ex.Message);
            }
        }

        private void tblProfile_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}