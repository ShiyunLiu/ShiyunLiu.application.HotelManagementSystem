using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelManagement.Core.Entities
{
    public class Service
    {
        public int Id { get; set; }
        [Column(name: "ROOMNO")]
        public int? RoomId { get; set; }
        public string SDesc { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? ServiceDate { get; set; }
        public Room Room { get; set; }
    }
}
