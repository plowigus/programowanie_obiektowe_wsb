using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsb_hotel_app
{
    public class Room
    {
       
        public int RoomNumber { get; set; }      
        public string RoomType { get; set; }      
        public decimal PricePerNight { get; set; }    
        public bool IsAvailable { get; set; }

        
        public Room(int roomNumber, string roomType, decimal pricePerNight, bool isAvailable)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            PricePerNight = pricePerNight;
            IsAvailable = isAvailable;
        }
    }
}
