using System;

namespace CarAgancyLogin.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string VehicleType { get; set; }    // نوع وسیله نقلیه
        public string PlateNumber { get; set; }    // شماره پلاک
        public string Model { get; set; }          // مدل
        public string Color { get; set; }          // رنگ
        public int ManufactureYear { get; set; }   // سال ساخت
        public string FuelType { get; set; }       // نوع سوخت
        public DateTime InsuranceExpiryDate { get; set; }  // تاریخ انقضای بیمه
        public string DriverUsername { get; set; } // نام کاربری راننده (ForeignKey)
    }
}
