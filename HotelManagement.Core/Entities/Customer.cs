using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;

namespace HotelManagement.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [Column(name: "ROOMNO")]
        public int? RoomId { get; set; }
        public string CName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? CheckIn { get; set; }
        public int? TotalPersons { get; set; }
        public int? BookingDays { get; set; }
        public Decimal? Advance { get; set; }
        public Room Room { get; set; }
    }
}
