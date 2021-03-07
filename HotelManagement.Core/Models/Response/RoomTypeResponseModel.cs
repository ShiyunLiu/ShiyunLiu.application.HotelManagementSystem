using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Core.Models.Response
{
    public class RoomTypeResponseModel
    {
        public int Id { get; set; }
        public string RtDesc { get; set; }
        public decimal? Rent { get; set; }
        public ICollection<RoomResponseModel> Rooms { get; set; }

    }
}
