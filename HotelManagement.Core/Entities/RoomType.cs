using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Core.Entities
{
    public class RoomType
    {
        public int Id { get; set; }
        public string RtDesc { get; set; }
        public decimal? Rent { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
