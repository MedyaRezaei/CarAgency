namespace CarAgancyLogin.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phonenumber { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string LicenseNumber { get; set; }  // شماره گواهینامه برای راننده‌ها
        public bool? IsAvailable { get; set; }     // وضعیت در دسترس بودن (در صورت نیاز)
    }
}
