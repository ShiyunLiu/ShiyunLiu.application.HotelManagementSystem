using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;

namespace HotelManagement.Core.Entities
{
    public class Room
    {
        public int Id { get; set; }
        [Column(name: "RTCODE")]
        public int? RoomTypeId { get; set; }
        public bool? Status { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public RoomType RoomType { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
