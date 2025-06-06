using System;

namespace CarAgancyLogin.Models
{
    public class Reservation
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string ReservationType { get; set; }
        public string DriverUsername { get; set; }
        public DateTime ReservationDate { get; set; }

    }
}
