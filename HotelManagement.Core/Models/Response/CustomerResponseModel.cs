using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Core.Models.Response
{
    public class CustomerResponseModel
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string CName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? CheckIn { get; set; }
        public int? TotalPersons { get; set; }
        public int? BookingDays { get; set; }
        public Decimal? Advance { get; set; }
        public RoomResponseModel Room { get; set; }

    }
}
