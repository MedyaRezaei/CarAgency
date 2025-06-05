﻿namespace CarAgancyLogin.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phonenumber { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string VehicleType { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
