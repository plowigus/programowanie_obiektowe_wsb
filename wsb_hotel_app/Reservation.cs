using System;

namespace wsb_hotel_app
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int RoomId { get; set; }
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Reservation(int reservationId, int roomId, int clientId, string firstName, string lastName, DateTime startDate, DateTime endDate)
        {
            ReservationId = reservationId;
            RoomId = roomId;
            ClientId = clientId;
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
